
$(document).ready(Initialize);

function Initialize() {
   
     $(":input[type='checkbox']").wijcheckbox();
    
    $("#datefrom2").wijcalendar({
        culture:"de-DE", 
        selectionMode:{day:true, days:false},
         displayDate: new Date()

         });

    $("#datefrom2").wijcalendar("selectDate", new Date());
   
 
    window.setInterval(Pulsate, 1000);
    window.setInterval(viewModel.load, 5000);
    $("#markets").wijgrid({
        culture:"de-DE",
        rowStyleFormatter:FormatMarketRows,
        allowEditing:false,
        selectionMode:"singleRow",
        allowPaging:true,
        pageSize:15,
        showFooter:false,
        showFilter:false,
        selectionChanged:MarketSelectionChanged,
        allowSorting:true,
        allowColSizing:true,
        columns:[
            { headerText:'Market ID', allowSort:true, allowSizing:true, dataType:'string', dataFormatString:'d' },
            { headerText:'Name', allowSizing:true, allowSort:true, dataType:'string', dataFormatString:'d' },
            { headerText:'Event Date', allowSizing:true, allowSort:true, dataType:'datetime', dataFormatString:'dd.MM.yyyy HH:mm:ss'},
            { headerText:'Live', allowSizing:true, allowSort:true, dataType:'string', dataFormatString:'d' }
        ]
    });

    $("#selections").wijgrid({
        culture:"de-DE",
        rowStyleFormatter:FormatSelectionRows,
        allowEditing:false,
        selectionMode:"singleRow",
        allowPaging:true,
        ageSize:10,
        showFooter:false,
        showFilter:false,
        allowSorting:true,
        allowColSizing:true,
        columns:[
            { headerText:'Selection ID', allowSort:true, allowSizing:true, dataType:'string', dataFormatString:'d' },
            { headerText:'Selection Name', allowSizing:true, allowSort:true, dataType:'string', dataFormatString:'d', },
            { headerText:'Market Name', allowSizing:true, allowSort:true, dataType:'string', dataFormatString:'d', visible:false}
        ]
    });

    ko.applyBindings(viewModel);
    viewModel.load();
}
function FormatMarketRows(args) {
    var wg = $.wijmo.wijgrid;

    if ((args.state === wg.renderState.rendering) && (args.type & wg.rowType.data)) {

        if (args.data.IsHot == "true") {
            $(args.$rows[0]).addClass("pulsate");
        }
    }
}

function FormatSelectionRows(args) {
    var wg = $.wijmo.wijgrid;

    if ((args.state === wg.renderState.rendering) && (args.type & wg.rowType.data)) {
        args.$rows.dblclick(SelectionChanged);

    }
}

function MarketSelectionChanged(e, args) {

    var selectedMarket = args.addedCells.item(0).value();
    viewModel.loadSelections(selectedMarket);
}

function SelectionChanged() {
    var selection = $("#selections").wijgrid("selection").selectedCells().item(0).value();
    var market = $("#markets").wijgrid("selection").selectedCells().item(0).value();
    var isHot = $("#markets").wijgrid("selection").selectedCells().item(3).value();

    var divId = "trackers_"+selection;
    var existingDiv = $("#trackers_" + selection);
    if (existingDiv.length == 0) $("#trackers").append("<div id='"+divId+"'></div>");
    $("#"+divId).wijdialog({contentUrl:huctools.GetBaseURL()+"selectiontrack/Default?marketId=" + market + "&selectionId=" + selection+"&isHot="+isHot, width:800, height:800});
}


function Pulsate() {

    $(".pulsate").effect("pulsate", { times:1 }, 500);
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


