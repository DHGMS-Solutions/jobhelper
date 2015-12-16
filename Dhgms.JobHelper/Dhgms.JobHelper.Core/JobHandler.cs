// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobHandler.cs" company="DHGMS Solutions">
//   Copyright 2004-2015 DHGMS Solutions.
//      
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//      
//   http://www.apache.org/licenses/LICENSE-2.0
//      
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the possibilities for Application Instance Locking through a
//   mutex.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.JobHelper.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Splat;

    /// <summary>
    ///     Generic class for an programs run, takes out the workload from error handling and reporting
    /// </summary>
    /// <typeparam name="TJobResultClass">
    ///     Result information relating to a job
    /// </typeparam>
    /// <typeparam name="TJobClass">
    ///     The class containing the processing logic for a job
    /// </typeparam>
    /// <typeparam name="TApplicationSettings">
    ///     Application settings relating to a job
    /// </typeparam>
    public sealed class JobHandler<TJobResultClass, TJobClass, TApplicationSettings> : IDisposable, IEnableLogger
        where TJobResultClass : IJobResult, new()
        where TApplicationSettings : IApplicationConfiguration
        where TJobClass : IJob<TApplicationSettings, TJobResultClass>, new()
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="JobHandler{TJobResultClass,TJobClass,TApplicationSettings}" /> class.
        /// </summary>
        /// <param name="programName">
        ///     The program Name.
        /// </param>
        /// <param name="programGuid">
        ///     The job unique identifier.
        /// </param>
        /// <param name="applicationInstanceMutexLock">
        ///     The type of mutex lock to apply to the program
        /// </param>
        /// <param name="serviceLocator">
        ///     The service locator, used for providing config, logging and reporting, etc.
        /// </param>
        public JobHandler(
            string programName,
            Guid programGuid,
            ApplicationInstanceMutexLock applicationInstanceMutexLock,
            IServiceLocator<TApplicationSettings, TJobResultClass> serviceLocator)
        {
            if (serviceLocator == null)
            {
                throw new ArgumentNullException("serviceLocator");
            }

            this.ApplicationInstanceMutexLock = applicationInstanceMutexLock;
            this._programName = programName;
            this._programGuid = programGuid;
            this._serviceLocator = serviceLocator;

            this._jobNotificationListeners = this._serviceLocator.GetJobNotificationListeners();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets how to apply a mutex lock to this process
        /// </summary>
        public ApplicationInstanceMutexLock ApplicationInstanceMutexLock { get; private set; }

        #endregion

        #region Constants and Fields

        /// <summary>
        ///     The unique identifier for the job.
        /// </summary>
        private readonly Guid _programGuid;

        /// <summary>
        ///     The program name.
        /// </summary>
        private readonly string _programName;

        /// <summary>
        ///     The _mutex.
        /// </summary>
        private Mutex _mutex;

        /// <summary>
        ///     The service locator.
        /// </summary>
        private readonly IServiceLocator<TApplicationSettings, TJobResultClass> _serviceLocator;

        private readonly IReadOnlyCollection<IJobNotificationListener<TJobResultClass>> _jobNotificationListeners;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Entry point for disposing the object
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        ///     Entry point for doing the work
        /// </summary>
        /// <returns>
        ///     The <see cref="int" />.
        /// </returns>
        public async Task<int> Process()
        {
            this.Log().Debug("Start of Job Handler.");

            // we don't want to catch and log exceptions if debugging
            // don't remove this conditional
            // it's here to prevent logging spam and to allow the debugger to work properly
            if (Debugger.IsAttached)
            {
                await this.DoJob();
            }
            else
            {
                // not being debugged so we want to set up mini dump
                // we only use for minidumps
                // emails and reports are handled by the providers as we want to cater different reports
                // to different targets on the same channel
                this.DoWatcher();

                try
                {
                    await this.DoJob();
                }
                catch (Exception e)
                {
                    this.Log().ErrorException("Exception in Processing of Job", e);
                    if (e is OutOfMemoryException)
                    {
                        // oops
                        // try to get the app back into a state where it can definately produce notifications
                        GC.Collect();
                    }

                    try
                    {
                        // we catch in case the config file is screwed
                        this.OnJobFailure(this._programGuid, this._programName, 0, e);
                    }
                        // ReSharper disable EmptyGeneralCatchClause
                    catch
                        // ReSharper restore EmptyGeneralCatchClause
                    {
                        // we want the original exception going to the console
                        // not the exception that it can't log the fault

                        // prevents the exception on failing to log
                        return 2;
                    }

                    return 1;
                }
            }

            this.Log().Debug("End of Job Handler.");

            return 0;
        }

        private void OnJobFailure(Guid programGuid, string programName, int i, Exception exception)
        {
            if (this._jobNotificationListeners != null && this._jobNotificationListeners.Count > 0)
            {
                foreach (var jobNotificationListener in this._jobNotificationListeners)
                {
                    try
                    {
                        jobNotificationListener.OnJobFailure(programGuid, programName, i, exception);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     does the donkey work for disposing the object
        /// </summary>
        /// <param name="disposing">
        ///     whether we're being disposed
        /// </param>
        private void Dispose(bool disposing)
        {
            this.Log().Debug("Start of Dispose.");

            if (!disposing)
            {
                return;
            }

            // dispose managed resources
            if (this._mutex != null)
            {
                this._mutex.ReleaseMutex();
            }

            // free native resources
            this.Log().Debug("End of Dispose.");
        }

        /// <summary>
        ///     Sets up the watcher for handling crash dumps
        /// </summary>
        private void DoWatcher()
        {
            this.Log().Debug("Start of DoWatcher.");

            this.Log().Debug("End of DoWatcher.");
        }

        /// <summary>
        ///     Does the actual work for running the task and handling the result
        /// </summary>
        private async Task DoJob()
        {
            this.Log().Debug("Start of DoJob.");

            if (this.ApplicationInstanceMutexLock != ApplicationInstanceMutexLock.None)
            {
                // try to set up a mutex
                var mutexName = this.GetMutexName();
                try
                {
                    this._mutex = Mutex.OpenExisting(mutexName);

                    this.Log().Error("The mutex for this job already exists. Indicating it is already running.");

                    // mutex already exists
                    // drop out
                    return;
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    this._mutex = new Mutex(true, mutexName);
                }
            }

            var job = new TJobClass();

            var settings = this._serviceLocator.GetConfigurationLoader().GetApplicationSettings();
            var jobResult = await job.Execute(settings);

            // in future we'll thread the job so we can handle cancellations
            this.Log().Info("Starting Job Success Notification.");
            this.OnJobSucess(this._programGuid, this._programName, jobResult);
            this.Log().Info("Finished Job Success Notification.");

            this._mutex.ReleaseMutex();

            this.Log().Debug("End Of DoJob.");
        }

        private void OnJobSucess(Guid guid, string s, TJobResultClass jobResult)
        {
            if (this._jobNotificationListeners != null && this._jobNotificationListeners.Count > 0)
            {
                foreach (var jobNotificationListener in this._jobNotificationListeners)
                {
                    try
                    {
                        jobNotificationListener.OnJobSucess(guid, s, jobResult);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the mutex name that should be used for the mutex lock
        /// </summary>
        /// <returns>
        ///     the mutex name that should be used for the mutex lock
        /// </returns>
        private string GetMutexName()
        {
            switch (this.ApplicationInstanceMutexLock)
            {
                case ApplicationInstanceMutexLock.PerSystemFullyQualifiedPath:
                    return "Global\\" + Assembly.GetExecutingAssembly().GetName().CodeBase;
                case ApplicationInstanceMutexLock.PerSystemGuid:
                    return "Global\\" + this._programGuid;
                case ApplicationInstanceMutexLock.PerUserFullyQualifiedPath:
                    return "Local\\" + Assembly.GetExecutingAssembly().GetName().CodeBase;
                case ApplicationInstanceMutexLock.PerUserGuid:
                    return "Local\\" + this._programGuid;
                default:
                    throw new InvalidOperationException("ApplicationInstanceMutexLock not a valid value");
            }
        }

        #endregion
    }
}