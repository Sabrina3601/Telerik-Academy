window.onload = function () {
    var canvas = document.getElementById('ballBounce');
    var ctx = canvas.getContext("2d");


    //ctx.rect(50, 50, 350, 250);
    // ctx.stroke();

    function drawBall(x, y, r, from, to) {
        ctx.beginPath();
        ctx.arc(x, y, r, from, to);
        ctx.stroke();
    }

    var x = 0,
        y = 0,
        r = 20,
        from = 0,
        to = Math.PI * 2,


        updateX = 5;
    updateY = 5;

    function moveBall() {
        ctx.strokeStyle = 'white';
        ctx.lineWidth = '2';

        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
        ctx.rect(0, 0, 350, 250);
        ctx.stroke();
        drawBall(x, y, r, from, to);

        if (x + r >= 350) {
            updateX = -5;
        }
        if (x + r <= 40) {
            updateX = 5;
        }

        if (y + r <= 40) {
            updateY = 5;
        }
        if (y + r >= 250) {
            updateY = -5;
        }

        x += updateX;
        y += updateY;

        requestAnimationFrame(moveBall);
    }
    requestAnimationFrame(moveBall);
}