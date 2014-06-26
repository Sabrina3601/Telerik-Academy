/**
 * Dependencies
 */
var Timer = require('./timer');

/**
 * Constructor
 * @constructor
 */
function Game(player1, player2, time, board) {
    this.id = null;
    if (player1) this.player1 = player1;
    if (player2) this.player2 = player2;
    if (time) this.time = time;
    this.timer = new Timer(time);
    if (board) this.board = board;
    this.playersTurn = this.player1['username'];
    this.generateId();
}

Game.prototype.generateId = function() {
    var rand = function () {
        return Math.random().toString(36).substr(2); // remove `0.`
    };
    this.id = rand() + rand();
};

Game.prototype.setId = function(id) {
    this.id = id;
};

Game.prototype.getId = function () {
    return this.id;
};

Game.prototype.setPlayer1 = function(player) {
    this.player1 = player;
};

Game.prototype.getPlayer1 = function () {
    return this.player1;
};

Game.prototype.setPlayer2 = function (player) {
    this.player2 = player;
};

Game.prototype.getPlayer2 = function () {
    return this.player2;
};

Game.prototype.setTime = function(time) {
    this.time = time;
};

Game.prototype.getTime = function() {
    return this.time;
};

Game.prototype.setStartTime = function(startTime) {
    this.startTime = startTime;
};

Game.prototype.getStartTime = function() {
    return this.startTime;
};

Game.prototype.setMaxExpire = function () {
    return this.startTime + this.time;
};

Game.prototype.getMaxExpire = function () {
    return this.maxExpire;
};

Game.prototype.setBoardId = function (boardId) {
    this.boardId = boardId;
};

Game.prototype.getBoardId = function () {
    return this.boardId;
};

module.exports = Game;