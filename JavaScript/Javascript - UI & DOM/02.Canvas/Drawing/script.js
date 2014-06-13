window.onload = function () {



    //start face
    var canvasFace = document.getElementById("canvas-holder");
    var context = canvasFace.getContext('2d');
    context.beginPath();
    context.arc(175, 240, 60, 0, 2 * Math.PI);
    context.strokeStyle = "blue";
    context.fillStyle = "lightblue";
    context.fill();
    context.stroke();
    context.closePath();

    //start hat
    context.beginPath();
    context.fillStyle = "darkblue";
    drawEllipse(175, 185, 180, 30, "darkblue", "black");
    drawEllipse(175, 170, 100, 25, "darkblue", "black");
    context.rect(138, 120, 75, 50);
    context.fill();
    drawEllipse(175, 120, 100, 30, "darkblue", "black");
    context.closePath();

    context.beginPath();
    context.moveTo(138, 120);
    context.strokeStyle = "black";
    context.lineTo(138, 175);
    context.moveTo(212, 120);
    context.lineTo(212, 175);
    context.stroke();
    context.closePath();

    //start eyes
    context.beginPath();
    drawEllipse(150, 220, 40, 15, "lightblue", "blue"); //left
    drawEllipse(200, 220, 40, 15, "lightblue", "blue");//right
    drawEllipse(145, 220, 10, 15, "blue", false);
    drawEllipse(195, 220, 10, 15, "blue", false);
    context.closePath();


    //start mouth
    context.beginPath();
    context.rotate(10 * Math.PI / 180);
    drawEllipse(215, 235, 60, 20, false, "blue");
    context.closePath();

    // start nose 
    context.beginPath();
    context.moveTo(205, 195);
    context.lineTo(195, 220);
    context.lineTo(210, 217);
    context.strokeStyle = "blue";
    context.stroke();




    function drawEllipse(centerX, centerY, width, height, fill, stroke) {

        context.beginPath();

        context.moveTo(centerX, centerY - height / 2);

        //some formula that i find in internet
        context.bezierCurveTo(
          centerX + width / 2, centerY - height / 2,
          centerX + width / 2, centerY + height / 2,
          centerX, centerY + height / 2);

        context.bezierCurveTo(
          centerX - width / 2, centerY + height / 2,
          centerX - width / 2, centerY - height / 2,
          centerX, centerY - height / 2);
        if (fill) {
            context.fillStyle = fill;
            context.fill();
        }
        if (stroke) {
            context.strokeStyle = stroke;
            context.stroke();
        }
        context.closePath();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Start Bycicle
    var canvas = document.getElementById("canvas-bike").getContext("2d");
    canvas.strokeStyle = "blue";
    canvas.lineWidth = 2;
    //wheels
    canvas.moveTo(150, 250);
    canvas.arc(100, 250, 50, 0, Math.PI * 2, false);
    canvas.fillStyle = "lightblue";

    canvas.moveTo(350, 250);
    canvas.arc(300, 250, 50, 0, Math.PI * 2, false);

    canvas.fill();

    canvas.moveTo(200, 250);
    canvas.arc(185, 250, 15, 0, Math.PI * 2, false);

    //the pedals
    canvas.moveTo(175, 240);
    canvas.lineTo(165, 230);

    canvas.moveTo(195, 260);
    canvas.lineTo(205, 270);

    //bicycle frame
    canvas.moveTo(185, 250);
    canvas.lineTo(100, 250);
    canvas.lineTo(155, 190);
    canvas.lineTo(290, 190);

    canvas.moveTo(145, 170);
    canvas.lineTo(185, 250);
    canvas.lineTo(290, 190);

    canvas.moveTo(300, 250);
    canvas.lineTo(285, 155);
    canvas.lineTo(240, 170);

    canvas.moveTo(125, 170);
    canvas.lineTo(165, 170);

    canvas.moveTo(285, 155);
    canvas.lineTo(310, 120);

    canvas.stroke();
    //End Bycicle



    ///////////////////////////////////////////////////////////////////////////////////////////

    //start house

    var canvasHouse = document.getElementById("canvas-house").getContext("2d");
    
    canvasHouse.rect(50, 181, 300, 200);
    canvasHouse.lineWidth = 2;
    canvasHouse.fillStyle = "darkred";
    canvasHouse.strokeStyle = "black";
    canvasHouse.fill();
    canvasHouse.stroke();

    

    /// start roof
    canvasHouse.beginPath();
    canvasHouse.moveTo(50, 180);
    canvasHouse.lineTo(200, 50);
    canvasHouse.lineTo(350, 180);
    canvasHouse.fillStyle = "darkred";
    canvasHouse.strokeStyle = "black";
    canvasHouse.fill();
    canvasHouse.stroke();
    canvasHouse.closePath();

    //start door
    canvasHouse.beginPath();
    canvasHouse.moveTo(80, 300)
    canvasHouse.lineTo(80, 380);
    canvasHouse.moveTo(150, 300)
    canvasHouse.lineTo(150, 380);
    canvasHouse.moveTo(80, 300);
    canvasHouse.bezierCurveTo(80, 270, 150, 270, 150, 300);
    canvasHouse.moveTo(115, 380);
    canvasHouse.lineTo(115, 278);   
    canvasHouse.strokeStyle = "black";
    canvasHouse.stroke();
    canvasHouse.closePath();

    canvasHouse.beginPath();
    canvasHouse.arc(100, 350, 5, 0, 2 * Math.PI);
    canvasHouse.stroke();
    canvasHouse.closePath();

    canvasHouse.beginPath();
    canvasHouse.arc(130, 350, 5, 0, 2 * Math.PI);
    canvasHouse.stroke();
    canvasHouse.closePath();

    //start windows
    canvasHouse.beginPath();
    canvasHouse.rect(70, 200, 40, 30);
    canvasHouse.rect(115, 200, 40, 30);
    canvasHouse.rect(70, 235, 40, 30);
    canvasHouse.rect(115, 235, 40, 30);
    canvasHouse.rect(290, 235, 40, 30);
    canvasHouse.rect(245, 235, 40, 30);
    canvasHouse.rect(245, 200, 40, 30);
    canvasHouse.rect(290, 200, 40, 30);
    canvasHouse.rect(290, 290, 40, 30);
    canvasHouse.rect(290, 325, 40, 30);
    canvasHouse.rect(245, 290, 40, 30);
    canvasHouse.rect(245, 325, 40, 30);
    canvasHouse.fillStyle = "black";
    canvasHouse.fill();
    canvasHouse.closePath();

    // start chimney
    canvasHouse.beginPath();
    canvasHouse.moveTo(260, 150);
    canvasHouse.lineTo(260, 70);
    canvasHouse.moveTo(290, 150);
    canvasHouse.lineTo(290, 70);
    canvasHouse.stroke();
    canvasHouse.rect(261, 70, 28, 80);
    canvasHouse.fillStyle = "darkred";
    canvasHouse.fill();
    canvasHouse.closePath();


    canvasHouse.beginPath();
    canvasHouse.moveTo(260,70);
    canvasHouse.bezierCurveTo(260, 65, 290, 65, 290, 70);
    canvasHouse.bezierCurveTo(290, 75, 260, 75, 260, 70);
    
    canvasHouse.fill();
    canvasHouse.stroke();

   


}