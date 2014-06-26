/**
 * Dependencies
 */

/**
 * Constructor
 * @constructor
 */
function Timer(time) {
    this.startTime = null;
    if (time) this.time = time;
    this.expireTime = null;
    this.player1Time = null;
    this.player2Time = null;

    this.setStartTime();
    this.setExpireTime();
    this.setPlayersStartTime();
}

Timer.prototype.setExpireTime = function() {
    this.expireTime = this.startTime + this.time;
};

Timer.prototype.setStartTime = function() {
    this.startTime = (new Date()).getTime();
};

Timer.prototype.setPlayersStartTime = function() {
    if (!this.startTime) this.setStartTime();
    this.player1Time = this.startTime + this.time;
    this.player2Time = this.startTime + this.time;
};

Timer.prototype.setPlayerTime = function(player, time) {
    if (player == 1) this.player1Time = time;
    else this.player2Time = time;
};

Timer.prototype.getPlayerTime = function(player) {
    return player == 1 ? this.player1Time : this.player2Time;
};

Timer.prototype.convertMsToTime = function(time) {
    var milliseconds = parseInt((time % 1000) / 100)
        , seconds = parseInt((time / 1000) % 60)
        , minutes = parseInt((time / (1000 * 60)) % 60)
        , hours = parseInt((time / (1000 * 60 * 60)) % 24);

    hours = (hours < 10) ? "0" + hours : hours;
    minutes = (minutes < 10) ? "0" + minutes : minutes;
    seconds = (seconds < 10) ? "0" + seconds : seconds;

    return hours + ":" + minutes + ":" + seconds + "." + milliseconds;
};

module.exports = Timer;


