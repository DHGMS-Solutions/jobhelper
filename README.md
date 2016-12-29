# DHGMS Job Helper

Job Helper is concept work around the following concepts:

* Jobs never execute in one place
* The state of job execution should be in one place
* Jobs should have a service level agreement against which they are measured

This project looks at different projects and methods of job execution in order to show how to:

* build a library of jobs and tasks
* centralize the job state
* report and alert job state

The core of the concept is agnostic hence there are samples with

* Quartz.NET
* Hangfire
* Azure WebJobs
