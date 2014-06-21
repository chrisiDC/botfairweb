$(document).ready(Initialize);

function Initialize() {
    $.validity.setup({ outputMode: "custom", modalErrorsClickable: true });

    $("#hotmarketsseconds").wijinputnumber(
        {
            type: 'numeric',
            decimalPlaces: 0,
        });

    $("#percentage").wijinputnumber(
        {
             type: 'numeric',
            decimalPlaces: 0,
        });

    $("#riskValue").wijinputnumber(
        {
             type: 'numeric',
            decimalPlaces: 0,
        });

    $("#newMarketsPeriod").wijinputnumber(
            {
                type: 'numeric',
            decimalPlaces: 0,
            })
     



    ko.applyBindings(viewModel);
    viewModel.load();

}

function LoadModel() {


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


function InsertConfig() {

    var x = validateMyAjaxInputs();

}


