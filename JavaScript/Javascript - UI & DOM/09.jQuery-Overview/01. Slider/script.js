$(document).ready(function () {
    var index = 0;
    $(".slide").hide();
    $('.slide').eq(index).show();


    $("#next").on("click", next);
    $("#prev").on("click", prev);

    var interval = setInterval(next, 5000);
    function prev() {
        $(".slide").eq(index).hide();
        index--;
        if (index === -1) {
            index = $(".slide").length - 1;
        }
        $('.slide').eq(index).show();
        resetTimer()
        console.log(index);
    }
    function next() {
        $(".slide").eq(index).hide();
        index++;
        if (index === $(".slide").length) {
            index = 0;
        }

        $('.slide').eq(index).show();
        resetTimer();
        console.log(index);
    }

    function resetTimer() {
        clearInterval(interval);
        interval = setInterval(next, 5000);
    }
})