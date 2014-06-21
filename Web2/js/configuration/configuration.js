$(document).ready(Initialize);

function Initialize() {

    $.validity.setup({ outputMode:"modal", modalErrorsClickable:true });


    $("#configurations").wijgrid({
        culture:"de-DE",
        allowEditing:true,
        selectionMode:"singleRow",
        allowPaging:true,
        pageSize:30,
        showFooter:true,
        showFilter:false,
        allowSorting:true,
        allowColSizing:true,
        beforeCellEdit:BeforeGridCellEdit,
        beforeCellUpdate:BeforeUpdate,


        //        cellStyleFormatter: function (args) {
        //            var $rt = $.wijmo.wijgrid.rowType;

        //            if ((args.row.type & $rt.data)) {
        //                var tmpl = document.getElementById("t1");

        //                if (tmpl) {
        //                    args.$cell.html(tmpl.text);
        //                    //                    args.$container.append(tmpl.text);
        //                    var bindingContext = args.$cell;// args.$container.get(0); //get Grid cell element
        //                    ko.applyBindings(self.dataRows()[args.row.dataItemIndex], bindingContext); //apply bindings to cell
        //                    return true;
        //                }
        //            }

        //            return true; // use default formatting
        //        },
        columns:[
            { headerText:'ID', allowSort:true, allowSizing:true, dataType:'number', dataFormatString:'n0', readOnly:true },
            {
                headerText:'HotMarketsSeconds',
                allowSizing:true,
                allowSort:true,
                dataType:'number',
                dataFormatString:'n0'
//                cellFormatter: function (args) {
//                   
//                    if (args.row.type & $.wijmo.wijgrid.rowType.data) {
//                        args.$container.append($("<p>" + args.row.data.HotMarketsSeconds + "</p>")); //.attr("src", args.row.data.Id);
//                    }
//                    return true;
//                }
            },
            { headerText:'Percentage', allowSizing:true, allowSort:true, dataType:'number', dataFormatString:'n1' },
            { headerText:'RiskValue', allowSizing:true, allowSort:true, dataType:'number', dataFormatString:'n0' },
            { headerText:'NewMarketsPeriod', allowSizing:true, allowSort:true, dataType:'number', dataFormatString:'n0' }
        ]
    });

    ko.applyBindings(viewModel);
    viewModel.load();

}

function LoadModel() {

    var result = huctools.ajax.LoadModel(huctools.GetBaseURL() + "/api/configuration/get?$orderby=Id");
    viewModel.configs(result);

   /* $.getJSON(huctools.GetBaseURL() + "/api/configuration/get?$orderby=Id", function (allData) {
        var arr = [];
        $.each(allData, function (i) {
            var config = new Config(allData[i]);
            SubscribeObject(config);
//                config.HotMarketsSeconds.extend({ 
//                     required: true,
//                 
//                 
//                 });

            arr.push(config);
        });

        viewModel.configs(arr);
    });*/
}

/*function SaveModel(viewModel,updates,url) {

    if (updates.length > 0) {
        var json = ko.toJSON(updates);

        $.ajax(url, {
            data:ko.toJSON(updates),
            datatype:json,
            type:"post",
            accepts:"application/json",
            contentType:"application/json",
            success:function (result) {

                viewModel.updates = [];
                alert("Ogspeichert!");
            },
            error:function (jqXHR, textStatus, errorThrown) {
                alert("error");
            }
        });
    }
    else alert("Oida host jo nix gendat!");

}*/

function BeforeGridCellEdit(e, args) {


//        var x= $("<div class='wijmo-wijgrid-innercell'>").appendTo(args.cell.container().empty());


    var x = $("<input/>")
        .appendTo(args.cell.container().empty()).wijinputnumber(
        {
            type:'numeric',
            minValue:0,
            maxValue:100000,
            decimalPlaces:0,
            showSpinner:false,
            value:args.cell.value()
        })
        .attr("id", "hotmarketsseconds")
        .focus();

    x.addClass("required email");
    args.handled = true;


}

function BeforeUpdate(e, args) {

    var x = validateMyAjaxInputs();
    return x;
}


function SubscribeObject(o, viewModel) {

    var self = this;
    _.each(_.keys(o), function (propertyName) {
        o[propertyName].subscribe(function () {
            self.viewModel.updates.push(this);

        }.bind(o));
    });

}

function ShowInsertDialog() {

    $("#insertconfig").wijdialog({ contentUrl: huctools.GetBaseURL() + "/configuration/insertconfig",
        modal: true,
        title: "Insert Configuration",
        closeOnEscape: true,
        closeText: "close",
        width: 600,
        height:400,
        captionButtons:
            {
                pin: { visible: false },
                refresh: { visible: false },
                toggle: { visible: false },
                minimize: { visible: false },
                maximize: { visible: false },
                close: { visible: true }
            }
    });
//    $("#insert_hotmarketsseconds").wijinputnumber(
//        {
//            type: 'numeric',
//            minValue: 0,
//            maxValue: 100000,
//            decimalPlaces: 0,
//            showSpinner: true,
//            value: 1
//        })
//        .focus();
}

function InsertConfig() {
    alert("here");
}


