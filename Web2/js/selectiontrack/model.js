var seriesEntry = function (data) {
    return {
        x:  ko.observableArray(data.x),
        y: ko.observableArray(data.y),
       
    };
};

var date =  new Date(2001, 1, 1);


var viewModel = {
    seriesList: ko.observableArray([]),
    axis: {
        y: { visible: true, autoMax: true, max: 8, text: 'Price',valueLabels:[] },
        x: { visible: true, autoMax: true, max: 8, text: 'Time' }
    },
    animation: { enabled: false, duration: 0 },
       load: function () {
           var start = $("#from").wijinputnumber("getText");
           var end = $("#to").wijinputnumber("getText");
        $.getJSON('../api/data/GetLineChartData?marketId=' + GetQueryStringParams("marketId") + '&selectionId=' + GetQueryStringParams("selectionId") + '&itemFrom='+start+'&itemTo='+end, function (allData) {
//            var arr = [];
//            $.each(allData.seriesList[0].data["x"], function (i) {
//                arr.push(new seriesEntry(allData.seriesList[0].data["x"][i]));
//            });

            viewModel.seriesList(allData.seriesList);
           
        });
           
    },
       
        refresh: function () {
           var start = $("#from").wijinputnumber("getText");
           var end = $("#to").wijinputnumber("getText");
        $.getJSON('../api/data/GetLineChartData?marketId=' + GetQueryStringParams("marketId") + '&selectionId=' + GetQueryStringParams("selectionId") + '&itemFrom='+start+'&itemTo='+end, function (allData) {
//            var arr = [];
//            $.each(allData.seriesList[0].data["x"], function (i) {
//                arr.push(new seriesEntry(allData.seriesList[0].data["x"][i]));
//            });

            viewModel.seriesList(allData.seriesList);
           
        });
           
    }
};