var huctools = {};
huctools.ajax = {};

huctools.ajax.SaveModel = function (viewModel, updates, url) {

    if (updates.length > 0) {
        var json = ko.toJSON(updates);

        $.ajax(url, {
            data:ko.toJSON(updates),
            dataType:"json",
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

}

huctools.ajax.LoadModel = function (url) {
    var model = [];
    $.ajax(
        {
            url:url,
            async: false,
            dataType:"json",
            contentType:"application/json",
            success:function (result) {

                $.each(result, function (i) {
                    model.push(result[i]);
                });

            },
            error:function (jqXHR, textStatus, errorThrown) {
                alert("ajax error");
            }
        });
    return model;
}

/* $.getJSON(url, function (allData) {
 var arr = [];
 $.each(allData, function (i) {
 model.push(allData[i]);
 });*/


huctools.GetBaseURL = function () {
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