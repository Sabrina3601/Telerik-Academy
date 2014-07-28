define(['tech-store-models/item'], function (item) {//namespace
    'use strict';
    var Store;//class
    Store = (function () {
        function Store(title) {//constructor
            this.title = title;
            this._items = [];
        }

        function sortByType(items, search, secondSearch) {
            var result = [];
            if (!secondSearch) {
                items.map(function (item) {
                    if (item.type === search) {
                        result.push(item);
                    }
                })
            }
            else {
                items.map(function (item) {
                    if (item.type === search || item.type == secondSearch) {
                        result.push(item);
                    }
                })
            }
            
            return result;
        }

        function sortLexico(items, type) {
            var result = items.sort(function (a, b) {
                return a[type].toLowerCase().localeCompare(b[type].toLowerCase());
            });
            return result;
        }

        function sortByPrice(items) {
            return items.sort(function (first, second) {
                return first.price - second.price;
            })
        }

        Store.prototype.addItem = function (item) {
            this._items.push(item);
            return this;
        }

        Store.prototype.getAll = function () {
            return sortLexico(this._items, 'name');
        }

        Store.prototype.getSmartPhones = function () {
            var search = 'smart-phone';
            var sortType = sortByType(this._items, search);
            var sortLexicographically = sortLexico(sortType,'name');
            return sortLexicographically;
        }

        Store.prototype.getMobiles = function () {            
            var sorted = sortByType(this._items, 'smart-phone', 'tablet');
            return sortLexico(sorted, 'name');
        }

        Store.prototype.getComputers = function () {           
            var sorted = sortByType(this._items, 'pc', 'notebook');
            return sortLexico(sorted,'name');
        }

        Store.prototype.filterItemsByType = function (type) {
            var sorted = sortByType(this._items, type);
            return sortLexico(sorted, 'name');
        }

        Store.prototype.filterItemsByPrice = function () {
            var args = arguments[0] || [];
            var min = args.min || 0;
            var max = args.max || +Infinity;
            var sorted = [];
            this._items.map(function (item) {
                if (item.price>= min && item.price<=max) {
                    sorted.push(item);
                }
            });
            
            return sortByPrice(sorted);
        }

        Store.prototype.countItemsByType = function () {
            var result = [];

            for (var i = 0; i < this._items.length; i++) {
                var curItem = this._items[i];
                if (result[curItem.type] === undefined) {
                    result[curItem.type] = 1;
                }
                result[curItem]++;
            }
            return result;
        }

        Store.prototype.filterItemsByName = function (searchName) {
            return sortLexico(this._items.slice().filter(function (item) {
                if (item.name.toLowerCase().indexOf(searchName.toLowerCase())) {
                    return true;
                }
                else {
                    return false;
                }
            }), 'name');

           
        }
        return Store;

    }());
    return Store;
});