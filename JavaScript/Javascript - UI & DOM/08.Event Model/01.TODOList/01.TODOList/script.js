window.onload = function () {
    var add = document.getElementById('add_btn');
    var list = document.getElementById('list');

    //add fucntion
    add.addEventListener('click', function () {
        var textValue = document.getElementById('text_value').value;
        if (textValue != "" && textValue != null) {
            var li = document.createElement('li');
            li.innerHTML = '<div class="add_list"><input type="checkbox" class="select" /><span>' + textValue + '</span><div>';
            list.appendChild(li);
        }
    });

    //delete function
    var deleteList = document.getElementById('delete_btn');
    deleteList.addEventListener('click', function () {
        var allLists = list.querySelectorAll('.select');
        for (var i = 0; i < allLists.length; i++) {
            if (allLists[i].checked) {
                allLists[i].parentElement.parentElement.parentElement.removeChild(allLists[i].parentElement.parentElement);
            }
        }
    });

    // hide function
    var hideList = document.getElementById('hide_btn');
    hideList.addEventListener('click', function () {
        var allLists = list.querySelectorAll('.select');
        for (var i = 0; i < allLists.length; i++) {
            if (allLists[i].checked) {
                allLists[i].parentElement.parentElement.style.display = "none";
            }
        }
    });

    // show function
    var showList = document.getElementById('show_btn');
    showList.addEventListener('click', function () {
        var allLists = list.querySelectorAll('.select');
        for (var i = 0; i < allLists.length; i++) {
            if (allLists[i].parentElement.parentElement.style.display === "none") {
                allLists[i].parentElement.parentElement.style.display = "block";
            }
        }
    });
}