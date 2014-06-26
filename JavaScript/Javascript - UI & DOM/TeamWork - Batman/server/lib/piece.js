/**
 * Dependencies
 */

/**
 * Constructor
 * @constructor
 */
function Piece(type, color) {
    this.types = {
        pawn: "pawn",
        rook: "rook",
        knight: "knight",
        bishop: "bishop",
        queen: "queen",
        king: "king"
    };
    if (type) this.type = this.types[type];
    if (color) this.color = color; // 1 - white, 2- black
    this.setId();
}

Piece.prototype.setType = function(type) {
    if (this.types[type]) this.type = type;
};

Piece.prototype.getType = function () {
    return this.type;
};

Piece.prototype.setColor = function (color) {
    this.color = color;
};

Piece.prototype.getColor = function () {
    return this.color;
};

Piece.prototype.setId = function() {
    if (this.color && this.type) {
        if (this.color == 1) this.id = "w" + this.type;
        if (this.color == 1) this.id = "b" + this.type;
    }
};

module.exports = Piece;