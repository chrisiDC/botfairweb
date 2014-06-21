
 var Config = function (data) {

    this.Id = ko.observable(data.Id);
    this.HotMarketsSeconds = ko.observable(data.HotMarketsSeconds),
    this.Percentage = ko.observable(data.Percentage);
    this.RiskValue = ko.observable(data.RiskValue);
    this.NewMarketsPeriod = ko.observable(data.NewMarketsPeriod);
};

var changes = [];

var viewModel = {

    configs: ko.observableArray([]),
    updates: [],
    load: function () {
        LoadModel();
    },
    save: function () {
        huctools.ajax.SaveModel(this,this.updates,huctools.GetBaseURL() + "/api/configuration/");
    }

};




