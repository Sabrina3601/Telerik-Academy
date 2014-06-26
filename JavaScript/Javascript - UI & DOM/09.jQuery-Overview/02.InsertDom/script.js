$(document).ready(function () {

    var insert = $("#input").val();

    $("#befor").on("click", function () {
        $('<div>' + insert + '</div>').insertBefore($('#insert'));
    });

    $("#after").on("click", function () {
        $('<div>' + insert + '</div>').insertAfter($('#insert'));
    });

})