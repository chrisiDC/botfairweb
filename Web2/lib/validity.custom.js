// First install the new output mode:
(function () {

    // We'll decide to install our custom output mode under the name 'custom':
    $.validity.outputs.custom = {

        // In this case, the start function will just reset the inputs:
        start: function () {

            $(".wijmo-wijinput").removeClass('fail');
            $("[id*='_validation']").detach();

        },

        end: function (results) {

            // If not valid and scrollTo is enabled, scroll the page to the first error.
            if (!results.valid && $.validity.settings.scrollTo) {
                location.hash = $(".fail:eq(0)").attr('id');
            }

        },

        // Our raise function will display the error and animate the text-box:
        raise: function ($obj, msg) {

            // Make the JavaScript alert box with the message:
            //            alert(msg);

            // Animate the border of the text box:
            var wijmoDiv = $obj.parent().parent();
            wijmoDiv.addClass('fail');
            wijmoDiv.parent().append("<span id='_validation'>"+msg+"</span>");

        },

        // Our aggregate raise will just raise the error on the last input:
        raiseAggregate: function ($obj, msg) {
            var self = this;
            $.each(map, function (key, value) {
                //                alert(key + ': ' + value);
                self.raise(value, msg);
                //                self.raise($($obj.get($obj.length - 1)), msg);
            });



        }
    }
})();
