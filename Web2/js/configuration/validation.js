
function validateMyAjaxInputs() {

  
    $.validity.start();

    $("#hotmarketsseconds").require().match("number").range(1, 5);
    $("#percentage").require().match("number").range(1, 100);
    $("#riskValue").require().match("number").range(1, 10000);
    $("#newMarketsPeriod").require().match("number").range(1, 10000);
    

    var result = $.validity.end();

   
    return result.valid;
}