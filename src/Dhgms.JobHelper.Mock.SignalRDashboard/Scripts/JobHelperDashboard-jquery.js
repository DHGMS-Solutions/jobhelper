// A simple templating method for replacing placeholders enclosed in curly braces.
if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}

$(function () {

    var ticker = $.connection.jobStateHub, // the generated client-side hub proxy
        //up = '▲',
        //down = '▼',
        $stockTable = $('#jobTable'),
        $stockTableBody = $stockTable.find('tbody'),
        rowTemplate = '<tr data-symbol="{JobGuid}"><td>{Name}</td></tr>';

    function formatJobState(jobState) {
        return $.extend(jobState, {
            //Price: stock.Price.toFixed(2),
            //PercentChange: (stock.PercentChange * 100).toFixed(2) + '%',
            //Direction: stock.Change === 0 ? '' : stock.Change >= 0 ? up : down
        });
    }

    function init() {
        ticker.server.ListJobs().done(function (jobStateModels) {
            $stockTableBody.empty();
            $.each(jobStateModels, function () {
                var jobStateModel = formatJobState(this);
                $stockTableBody.append(rowTemplate.supplant(jobStateModel));
            });
        });
    }

    // Add a client-side hub method that the server will call
    ticker.client.onJobUpdated = function (jobModel) {
        var displayJobModel = formatJobState(jobModel),
            $row = $(rowTemplate.supplant(displayJobModel));

        $stockTableBody.find('tr[data-symbol=' + displayJobModel.JobGuid + ']').replaceWith($row);
    }

    // Start the connection
    $.connection.hub.start().done(init);

});