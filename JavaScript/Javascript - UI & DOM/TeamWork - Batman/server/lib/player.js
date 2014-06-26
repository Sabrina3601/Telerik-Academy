/**
 * Dependencies
 */
var User = require('./user');
var Piece = require('./piece');

/**
 * Constructor
 * @constructor
 */
function Player(username, color, state) {
    this.username = username;
    if (color) this.color = color; // 1 white 2 black
    if (state) this.state = state; // 0 - Offline, 1 - Online, 2 - Seeking, 3 - AcceptedOffer, 4 - Ready , 5 - pre-game, 6 - Active
    this.pieces = [];
    this.setPieces();
}

Player.prototype.setUser = function (user) {
    this.user = user;
};

Player.prototype.getUser = function () {
    return this.user;
};

Player.prototype.setColor = function (color) {
    this.color = color;
};

Player.prototype.getColor = function () {
    return this.color;
};

Player.prototype.setTime = function (time) {
    this.time = time;
};

Player.prototype.getTime = function () {
    return this.time;
};

Player.prototype.addPiece = function (piece) {
    this.pieces.push(piece);
};

Player.prototype.removePiece = function (piece) {
    for (var i = 0; i < this.pieces.length; i++) {
        if (this.pieces[i].id == piece.id) delete this.pieces[i];
    }
};

Player.prototype.setPieces = function () {
    // start position of pieces
    var cnt = 0;
    for (var i = 0; i < 8; i++) {
        this.addPiece(new Piece(cnt++, "pawn", this.color));
    }

    this.addPiece(new Piece(cnt++, "rook", this.color));
    this.addPiece(new Piece(cnt++, "rook", this.color));
    this.addPiece(new Piece(cnt++, "knight", this.color));
    this.addPiece(new Piece(cnt++, "knight", this.color));
    this.addPiece(new Piece(cnt++, "bishop", this.color));
    this.addPiece(new Piece(cnt++, "bishop", this.color));
    this.addPiece(new Piece(cnt++, "queen", this.color));
    this.addPiece(new Piece(cnt++, "king", this.color));
};

Player.prototype.setState = function (state, callback) {
    this.state = state;
};

module.exports = Player;


