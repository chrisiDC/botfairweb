var bet = function (data) {
    return {
//        MarketId:ko.observable(data.MarketId),
        MarketName:ko.observable(data.MarketName),
        MarketStart:ko.observable(data.EventDate),
         SelectionName:ko.observable(data.SelectionName),
//        SelectionId:ko.observable(data.SelectionId),
        MoneyPosted:ko.observable(data.MoneyPosted),
       
        PricePosted:ko.observable(data.PricePosted),
        Type:ko.observable(data.Type),
        Date:ko.observable(data.DatePosted),
        Win:ko.observable(data.Win)
      
    };
};

var viewModel = {

    bets:ko.observableArray([]),
    load:function () {

        $.getJSON(GetBaseURL()+"/api/bets/get?$orderby=MarketId", function (allData) {
            var arr = [];
            $.each(allData, function (i) {
                arr.push(new bet(allData[i]));
            });

            viewModel.bets(arr);
        });
    },

};

