$(document).ready(Initialize);

function Initialize() {

 
    $("#bets").wijgrid({
        culture: "de-DE",
        allowEditing: true,
        selectionMode: "singleRow",
        allowPaging: true,
         pageSize: 30,
        showFooter: false,
        showFilter: true,
        allowSorting: true,
        allowColSizing: true,
//        columns: [
//            { headerText: 'ID', allowSort: true, allowSizing: true, dataType: 'string', dataFormatString: 'd' },
//            { headerText: 'HotMarketsSeconds', allowSizing: true, allowSort: true, dataType: 'string', dataFormatString: 'd' },
//            { headerText: 'Percentage', allowSizing: true, allowSort: true, dataType: 'string', dataFormatString: 'd' },
//                   { headerText: 'RiskValue', allowSizing: true, allowSort: true, dataType: 'string', dataFormatString: 'd' },
//                     { headerText: 'NewMarketsPeriod', allowSizing: true, allowSort: true, dataType: 'string', dataFormatString: 'd' }
//        ]
    });

    ko.applyBindings(viewModel);
    viewModel.load();


}

  function GetBaseURL() {
    var url = location.href;  // entire url including querystring - also: window.location.href;
    var baseURL = url.substring(0, url.indexOf('/', 14));


    if (baseURL.indexOf('http://localhost') != -1) {
        // Base Url for localhost
        var url = location.href;  // window.location.href;
        var pathname = location.pathname;  // window.location.pathname;
        var index1 = url.indexOf(pathname);
        var index2 = url.indexOf("/", index1 + 1);
        var baseLocalUrl = url.substr(0, index2);

        return baseLocalUrl + "/";
    }
    else {
        // Root Url for domain name
        return baseURL + "/";
    }

}