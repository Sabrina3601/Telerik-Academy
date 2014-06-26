$('document').ready(function () {

    $.fn.dropdown = function () {

        // Get the Raw Data from the original Select
        var $selectTag = $(this);
        $selectTag.hide();
        var optionsArr = [];
        var options = $selectTag.children();

        for (var i = 0; i < options.length; i++) {
            optionsArr.push({
                option: options[i].text,
                value: options[i].value
            });
        }

        // Generate new List
        var $container = $('<div>').addClass('dropdown-list-container');
        var $ul = $('<ul>').addClass('dropdown-list-options');
        var $selectionContainer = $('<li>')
                .addClass('dropdown-list-selectionContainer')
                .text('Choose your Number')
                .attr('data-value', 'not-selected')
                .appendTo($ul);

        for (var j = 0; j < optionsArr.length; j++) {
            var currOption = $('<li>')
                    .text(optionsArr[j].option)
                    .attr('data-value', optionsArr[j].value)
                    .addClass("lists")
                    .on('click', function () {
                        $target = $(this);
                        $('.dropdown-list-selectionContainer').attr('data-value', $target.attr('data-value'));
                        $target.attr('selected', 'selected');
                        $('.dropdown-list-selectionContainer').text($target.text());
                        $('.lists').slideUp();
                    })
                    .appendTo($ul);
        }
        $allOptions = $ul.children(".lists").hide();

        $selectionContainer.on('click', function () {
            $allOptions.slideToggle();
        })
        $ul.appendTo($container);
        $container.appendTo($('body'));
    };

    $('#dropdown').dropdown();
});