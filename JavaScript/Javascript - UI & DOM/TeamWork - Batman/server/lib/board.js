/**
 * Dependencies
 */
var Piece = require('./piece');

/**
 * Constructor
 * @constructor
 */
function Board() {
    this.board = {
        8: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        7: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        6: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        5: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        4: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        3: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        2: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null },
        1: { a: null, b: null, c: null, d: null, e: null, f: null, g: null, h: null }
    };
    this.pieces = [];
    this.setStartPos();
    this.moves = [];
}

Board.prototype.setStartPos = function() {
    // Two rows with pawns for black and white
    for (var s in this.board[7]) {
        this.board[2][s] = new Piece("pawn", 1);
    }
    for (var n in this.board[7]) {
        this.board[7][n] = new Piece("pawn", 2);
    }

    // rest of figures for white
    this.board[1]['a'] = new Piece("rook", 1);
    this.pieces.push(this.board[1]['a']['id']);

    this.board[1]['b'] = new Piece("knight", 1);
    this.pieces.push(this.board[1]['b']['id']);

    this.board[1]['c'] = new Piece("bishop", 1);
    this.pieces.push(this.board[1]['c']['id']);

    this.board[1]['d'] = new Piece("queen", 1);
    this.pieces.push(this.board[1]['d']['id']);

    this.board[1]['e'] = new Piece("king", 1);
    this.pieces.push(this.board[1]['e']['id']);

    this.board[1]['f'] = new Piece("bishop", 1);
    this.pieces.push(this.board[1]['f']['id']);

    this.board[1]['g'] = new Piece("knight", 1);
    this.pieces.push(this.board[1]['g']['id']);

    this.board[1]['h'] = new Piece("rook", 1);
    this.pieces.push(this.board[1]['h']['id']);
    // rest of figures for black
    this.board[8]['a'] = new Piece("rook", 2);
    this.pieces.push(this.board[1]['a']['id']);

    this.board[8]['b'] = new Piece("knight", 2);
    this.pieces.push(this.board[1]['b']['id']);

    this.board[8]['c'] = new Piece("bishop", 2);
    this.pieces.push(this.board[1]['c']['id']);

    this.board[8]['d'] = new Piece("queen", 2);
    this.pieces.push(this.board[1]['d']['id']);

    this.board[8]['e'] = new Piece("king", 2);
    this.pieces.push(this.board[1]['e']['id']);

    this.board[8]['f'] = new Piece("bishop", 2);
    this.pieces.push(this.board[1]['f']['id']);

    this.board[8]['g'] = new Piece("knight", 2);
    this.pieces.push(this.board[1]['g']['id']);

    this.board[8]['a'] = new Piece("rook", 2);
    this.pieces.push(this.board[1]['h']['id']);
};

Board.prototype.validateMove = function(move, callback) {
    // Validate new move
    // Check if square is free
    // Check if not exposed check
    // Check if is legal move by figure
    


    callback();
};


module.exports = Board;