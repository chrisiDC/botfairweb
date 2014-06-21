
$(document).ready(Initialize);

function Initialize() {
    $("#from").wijinputnumber(

        {
            type: 'numeric',
            value: 0,
            minValue: 0,
            maxValue: 1000,
            decimalPlaces: 0,
            showSpinner: true
        });
    $("#to").wijinputnumber(

        {
            type: 'numeric',
            value: 10,
            minValue: 0,
            maxValue: 1000,
            decimalPlaces: 0,
            showSpinner: true
        });
    $("#linechart").wijlinechart({ chartLabelFormatString: "n0" });
    ko.applyBindings(viewModel);
    viewModel.load();
    var isHot = GetQueryStringParams("isHot");

    if (isHot) {
        window.setInterval(viewModel.refresh, 1000);
    }
}

function GetQueryStringParams(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.search);
        if (results == null)
            return "";
        else
            return decodeURIComponent(results[1].replace(/\+/g, " "));
    }

