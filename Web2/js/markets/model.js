var market = function (data) {
    return {
        Id:ko.observable(data.Id),
        Name:ko.observable(data.Name),
        EventDate:ko.observable(data.EventDate),
        IsHot:ko.observable(data.IsHot),
    };
};

var selection = function (data) {
    return {
        SelectionId:ko.observable(data.SelectionId),
        Name:ko.observable(data.Name),
        MarketId:ko.observable(data.MarketId),


    };
};

var viewModel = {

    markets:ko.observableArray([]),
    selections:ko.observableArray([]),
    load:function () {
//        http://localhost:669/botfair2/api/data/getmarkets?$orderby=EventDate desc&$filter=EventDate ge datetime'2012-11-06T00:00:00Z' and EventDate lt datetime'2012-11-06T23:59:59'
//        http://localhost:669/botfair2/api/data/GetMarkets?$orderby=EventDate desc&$filter=EventDate gt datetime'2012-11-06T00:00:00Z and EventDate lt datetime'2012-11-06T23:59:59Z'

      
        var date = $('#datefrom2').wijcalendar("getSelectedDate");
        var serverDate = "";
        var serverDateTo = "";
        if (date != null) {

            serverDate = date.format("yyyy-MM-dd") + "T00:00:00Z";
            serverDateTo=date.format("yyyy-MM-dd") + "T23:59:59Z";
        }

//        var clientFrom = moment($('#datefrom2').wijcalendar("getSelectedDate"),"DD.MM.YYYY");
//        var serverFrom = moment.format("YYYY-MM-DD")+"T00:00:00Z";

        var showAll = $('#showall').attr("checked");
        var requestString = GetBaseURL()+"/api/data/GetMarkets?$orderby=EventDate desc&$filter=EventDate gt datetime'" + serverDate + "' and EventDate lt datetime'"+serverDateTo+"'";
        if (showAll == "checked") requestString = GetBaseURL()+"/api/data/GetMarkets?$orderby=EventDate desc";
        
        $.getJSON(requestString, function (allData) {
            var arr = [];
            $.each(allData, function (i) {
                arr.push(new market(allData[i]));
            });

            viewModel.markets(arr);
        });
    },

    loadSelections:function (id) {
        $.getJSON(GetBaseURL()+"/api/data/GetSelections?marketId=" + id, function (allData) {
            var arr = [];
            $.each(allData, function (i) {
                arr.push(new selection(allData[i]));
            });

            viewModel.selections(arr);
        });
    }
};