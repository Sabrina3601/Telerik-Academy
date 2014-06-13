
// Initialize constraints
var maxHeight = screen.height - 400;
var maxWidth = screen.width - 400;

var topX = 300;
var leftY = 300;

var circleRadius = 150;
var angle = 0;
var angleStep = 5;
var interval = 100;

var divCounter = 5;
var wrapper = document.getElementById("wrapper");

// Generate divs
for (var i = 0; i < divCounter; i++) {
    // Correct the angle
    angle += angleStep;
    generateDiv(wrapper, angle);
}

// Spin them all
var divs = document.getElementsByClassName("crazy");
var repeat = setInterval(function () {
    for (var i = 0, len = divs.length; i < len; i++) {
        // Correct the angle
        angle += angleStep;
        updatePosition(divs[i]);
    }
}, interval);

function updatePosition(currentElement) {
    var currentXPosition = topX + Math.cos(angle) * circleRadius;
    currentElement.style.top = currentXPosition + "px";

    var currentYPosition = leftY + Math.sin(angle) * circleRadius;
    currentElement.style.left = currentYPosition + "px";
}

function generateDiv(div, angle) {

    // Initialize div and set some styles
    var currentElement = document.createElement("div");
    currentElement.classList.add("crazy");
    currentElement.style.position = "absolute";
    currentElement.style.width = "50px";
    currentElement.style.height = "50px";
    currentElement.style.borderStyle = "dashed";
    currentElement.style.borderRadius = "50px";

    currentElement.style.background = "black";
    currentElement.style.borderColor = "yellowgreen";



    // Set start position
    updatePosition(currentElement);

    div.appendChild(currentElement);
}