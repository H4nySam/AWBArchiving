$(document).ready(function () {
    //alert('spinner init');

    $(".bnspinner").each(function (index, item) {
        var jsItem = $(item);
        var min = jsItem.attr("data-min");
        var max = jsItem.attr("data-max");
        var decimals = jsItem.attr("data-decimals");
        var step = jsItem.attr("data-step");
        var step = jsItem.attr("data-step");
        var rounding = jsItem.attr("data-rounding");
        var readonlyinput = jsItem.attr("data-readonlyinput");
        var isReadonly = jsItem.attr("data-isreadonly");

        jsItem.TouchSpin({
            buttondown_class: 'btn default nomargine',
            buttonup_class: 'btn default nomargine',
            min: min,
            max: max,
            step: step,
            decimals: decimals,         //allow decimals, and number of decimals
            boostat: 10,
            maxboostedstep: 20,
            stepinterval: 120,          //the speed of the button holding incrementing
            forcestepdivisibility: rounding == 'True' ? 'round' : 'none',
            mousewheel: true,           //increment/decrement on mouse wheel events
            readonlyinput: (readonlyinput == 'True'),
            isreadonly: (isReadonly == 'True'),
            container: jsItem.parent(),
        });
    });
});