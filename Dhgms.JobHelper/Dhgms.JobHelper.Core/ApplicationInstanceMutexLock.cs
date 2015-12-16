// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationInstanceMutexLock.cs" company="DHGMS Solutions">
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
    /// <summary>
    /// Defines the possibilities for Application Instance Locking through a
    /// mutex.
    /// </summary>
    public enum ApplicationInstanceMutexLock
    {
        /// <summary>
        /// No Mutex Lock Applied.
        /// </summary>
        None,

        /// <summary>
        /// Global Mutex lock is done on the fully qualified path of the executable.
        /// In order to run multiple copies, they must be in different folders.
        /// </summary>
        PerSystemFullyQualifiedPath,

        /// <summary>
        /// Global Mutex lock is based on the Job guid.  In order to run multiple copies
        /// they need to be run on seperate machines
        /// </summary>
        PerSystemGuid,

        /// <summary>
        /// Local (session id) Mutex lock is done on the fully qualified path of the executable.
        /// In order to run multiple copies, they must be in different folders.
        /// </summary>
        PerUserFullyQualifiedPath,

        /// <summary>
        /// Local (session id) Mutex lock is based on the Job guid.  In order to run multiple copies
        /// they need to be run on seperate machines
        /// </summary>
        PerUserGuid,

        /// <summary>
        /// Advanced option. Uses the job control system to find out if the job is running anywhere else.
        /// </summary>
        PerGuid
    }
}
