/**
 * Dependencies
 */


/**
 * Constructor
 * @constructor
 */
function Match(id, player1, player2, time, startTime) {
    if (id) this._id = this.setId(id);
    if (player1) this.player1 = this.setPlayer1(player1);
    if (player2) this.player2 = this.setPlayer2(player2);
    if (time) this.time = this.setTime(time);
    if (startTime) this.startTime = this.setStartTime(startTime);
}

Match.prototype.setId = function(id) {
    this._id = id;
};

Match.prototype.getId = function () {
    return this._id;
};

Match.prototype.setPlayer1 = function(player) {
    this.player1 = player;
};

Match.prototype.getPlayer1 = function () {
    return this.player1;
};

Match.prototype.setPlayer2 = function (player) {
    this.player2 = player;
};

Match.prototype.getPlayer2 = function () {
    return this.player2;
};

Match.prototype.setTime = function(time) {
    this.time = time;
};

Match.prototype.getTime = function() {
    return this.time;
};

Match.prototype.setStartTime = function(startTime) {
    this.startTime = startTime;
};

Match.prototype.getStartTime = function() {
    return this.startTime;
};

module.exports = Match;