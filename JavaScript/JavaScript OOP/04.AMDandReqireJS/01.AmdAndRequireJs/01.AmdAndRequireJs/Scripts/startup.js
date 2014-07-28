/// <reference path="Libs/require.js" />
/// <reference path="Libs/jquery-1.11.1.js" />
/// <reference path="Libs/handlebars-v1.3.0 .js" />

(function () {

    require.config({
        paths: {
            'jquery': '//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min',
            'handlebars': '//cdnjs.cloudflare.com/ajax/libs/handlebars.js/2.0.0-alpha.4/handlebars.min',
            'controls': 'controls',
            'item': 'item'
        }
    });

    require(['jquery', 'controls'], function ($, controls) {

        var people = [
        { id: 1, name: "Дончо Минков", age: 18, avatarUrl: "/images/person.png" },
        { id: 2, name: "Тодор Стоянов", age: 19, avatarUrl: "/images/person.png" },
        { id: 3, name: "Ивайло Кенов", age: 18, avatarUrl: "/images/person.png" },
        { id: 4, name: "Николай Костов", age: 19, avatarUrl: "/images/person.png" }];

        var people2 = [
        { id: 1, name: "Pesho", age: 18, avatarUrl: "/images/person.png" },
        { id: 2, name: "Gosho", age: 19, avatarUrl: "/images/person.png" },
        { id: 3, name: "Ivan", age: 18, avatarUrl: "/images/person.png" },
        { id: 4, name: "Dragan", age: 19, avatarUrl: "/images/person.png" },
        { id: 5, name: "Petkan", age: 18, avatarUrl: "/images/person.png" }];

        var comboBox = new controls.ComboBox(people);
        var template = $('#sample-template').html();
        var comboBoxHtml = comboBox.render(template);
        $('#container').append(comboBoxHtml);

        $('#container').append($('<srong>').html('another content'));

        var comboBox2 = new controls.ComboBox(people2);
        var comboBoxHtml2 = comboBox2.render(template);
        $('#container').append(comboBoxHtml2);
    });

}());