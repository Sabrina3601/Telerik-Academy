'use strict';

var controler = (function () {


    function directions(direct, current) {
        var key = direct;
        var directions;
        //We will add another clause to prevent reverse gear
        if (key == "37" && current != "right") return directions = "left";
        else if (key == "38" && current != "down") return directions = "up";
        else if (key == "39" && current != "left") return directions = "right";
        else if (key == "40" && current != "up") return directions = "down";
        //The snake is now keyboard controllable
        
    };
    

    return {
        directions: directions
    }
})