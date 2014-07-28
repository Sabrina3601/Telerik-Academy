define(['handlebars'], function () {

    function item(data, template) {
        var compiledTemplate = Handlebars.compile(template);
        var item = compiledTemplate(data);
        return item;
    }

    return item;
});