$('<button>').text('Check').on('click', functionality).appendTo('body');

function functionality() {
    var $table = $('<table>')
        .appendTo('body');
    var $thead = $('<thead>').appendTo($table);
    var $tr = $('<tr>').appendTo($thead);
    $tr.append($('<th>').text('First name'));
    $tr.append($('<th>').text('Last name'));
    $tr.append($('<th>').text('Grade'));

    var $tbody = $('<tbody>').appendTo($table);
    for (var i in students) { // students is in the testArray.js
        var $stInfo = $('<tr>');
        $stInfo.append($('<td>').text(students[i].firstName));
        $stInfo.append($('<td>').text(students[i].lastName));
        $stInfo.append($('<td>').text(students[i].grade));

        $stInfo.appendTo($tbody);
    }
}