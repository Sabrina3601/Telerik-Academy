define(function () {//namespace
    'use strict';
    var Item;//class
    Item = (function () {
        function Item(type, name, price) {//constructor
            this.type = type;
            this.name = name;
            this.price = price;
        }

        return Item;

    }());
    return Item;
});