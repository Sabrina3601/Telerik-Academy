
define(['jquery', 'comboBox', 'test-data'], function (jquery, controls, people) {
    'use strict';

    var Run = (function () {
        function run(){
            var comboBox = controls.ComboBox(people);
            var template = $("#person-template").html();
            var comboBoxHtml = comboBox.render(template);
            $('#combo-box-container').html(comboBoxHtml);
        }
        return Run;
    }());

    return Run;
});