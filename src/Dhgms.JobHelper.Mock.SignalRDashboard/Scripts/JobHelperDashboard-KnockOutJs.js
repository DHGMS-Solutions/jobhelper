$(function () {

    var JobStateListViewModel = function () {
        this.allItems = ko.observableArray();
    };

    ko.applyBindings(new JobStateListViewModel());

    var ticker = $.connection.jobStateHub;

    function init() {
        // set up the signalr initial data burst
        ticker.server.listJobs().done(function (jobStateModels) {
            $.each(jobStateModels, function () {
                this.allItems.push(this);
            });
        });
    }

    // Callback for dealing with Job State updates from SignalR
    ticker.client.onJobUpdated = function (jobModel) {
        var updatedJob = ko.utils.arrayFirst(this.allItems,
            function(currentJobModel) {
                return currentJobModel.jobGuid() === jobModel.jobGuid;
            });

        updatedJob.lastUpdated(jobModel.lastUpdated());
        this.allItems.sort();
    }

    // Start the connection
    $.connection.hub.start().done(init);
});