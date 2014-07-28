/// <reference path="Libs/jquery-2.1.1.js" />
/// <reference path="Libs/require.js" />
define(['jquery', 'item'], function ($, item) {

    function ComboBox(people) {
        this._peopleData = people;
        return this;
    }

    ComboBox.prototype.render = function (template) {

        var $ComboBox = $('<div>');
        $ComboBox.addClass('combo-box');
        var $ComboBoxMain = $('<div>');
        $ComboBoxMain.addClass('main');
        var $ComboBoxMenu = $('<div>');
        $ComboBoxMenu.addClass('menu hiden');

        var compiledTemplate = Handlebars.compile(template);

        for (var i = 0; i < this._peopleData.length; i++) {
            var $item = $(item(this._peopleData[i], template));
            if (i == 0) {
                $ComboBoxMain.append($item.clone());
                $item.addClass('selected');
            }
            $ComboBoxMenu.append($item);
        }

        $ComboBoxMain.on('click', function () {
            $ComboBoxMenu.toggleClass('hiden');
        });

        $ComboBoxMenu.on('click', '.person-item', function () {
            console.log(this);
            $ComboBoxMenu.find('.person-item').removeClass('selected');
            $ComboBoxMain.html($(this).clone());
            $(this).addClass('selected');
            $ComboBoxMenu.toggleClass('hiden');
        });

        $ComboBox.append($ComboBoxMain).append($ComboBoxMenu);

        return $ComboBox;
    }

    return {
        ComboBox: ComboBox
    }
});