var market = function (data) {
    return {
     
        Name:ko.observable(data.Name),
        EventDate:ko.observable(data.EventDate),
        time:ko.observable(data.Time)
    };
};

var viewModel = {

    markets:ko.observableArray([]),
    load:function () {


        var requestString = GetBaseURL() + "/api/data/GetAllMarkets?dummy=0";
        $.getJSON(requestString, function (allData) {
            var arr = [];
            $.each(allData, function (i) {
                arr.push(new market(allData[i]));
            });

            viewModel.markets(arr);
        });
    }
};