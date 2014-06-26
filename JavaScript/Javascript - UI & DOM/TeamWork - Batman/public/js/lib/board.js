/*
 Class for the game board.
 */
// require canvas

/**
 * Constructor
 * @constructor
 */
function Board(player1, player2, time) {
    this.canvas = null;
    // initialize canvas
    // set mouseDown events on canvas
    // On mouse down send to server if the piece can be moved is players turn
    // if ok move it
    // else don't move it (show the piece cannot be moved)
    // set Starting position
    // send move
    // onMoveCallback

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

    if (player1) this.player1 = player1;
    if (player2) this.player2 = player2;
    if (time) this.player1Time = time;
    if (time) this.player2Time = time;
    this.moves = [];
    this.gameId = null;
    this.playersTurn = this.player1;
}

Board.prototype.init = function (callback) {
    this.canvas = new Canvas();
    this.canvas.setToStartPosition();
    this.initScoreBoard();
    callback();
};

Board.prototype.initScoreBoard = function () {
    // Init score-board
    // Set players names and times

};

Board.prototype.move = function(a, b) {

};

Board.prototype.requestMove = function(move) {
    // Move is verified by the canvas now verify it on the server
    app.verifyMove(this.gameId, authentication['user']['username'], this.moves, move, function(verified) {

    });
};

Board.prototype.syncMoves = function (game, callback) {
    // Check if all moves are up-to-date
    if (!this.gameId) this.gameId = game['id'];
    this.moves = game['board']['moves'];
    callback();
};




