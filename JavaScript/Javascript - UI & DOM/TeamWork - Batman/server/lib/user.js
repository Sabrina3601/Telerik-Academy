/*
    Dependencies
 */
var DB = require('./db');

var db = new DB();

/**
 * Constructor
 * @constructor
 */
var User = function(username, password, rank, email, token) {
    if (username) this.username = username;
    if (password) this.password = password;
    if (rank) this.rank = rank;
    if (email) this.email = email;
    if (token) this.token = token;
    this.state = 1; // 0 Offline 1 Online 2 Seeking 3 accepted offer 4 ready, 5 - pre-game, 6 - playing
};

User.prototype.setUsername = function(username) {
    if (this.verifyUsername(username)) {
        this.username = username;
        return true;
    }
    return false;
};

User.prototype.getUsername = function () {
    return this.username;
};

User.prototype.verifyUsername = function(username) {
    return (username.length > 3 && username.length <= 10);
};

User.prototype.setPassword = function(password) {
    if (this.verifyPassword(password)) {
        this.password = password;
        return true;
    }
    return false;
};

User.prototype.getPassword = function (password) {
    return this.password;
};

User.prototype.verifyPassword = function (password) {
    return (password.length > 3 && password.length <= 15);
};

User.prototype.setRank = function(rank) {
    if (this.verifyRank(rank)) {
        this.rank = rank;
        return true;
    }
    return false;
};

User.prototype.getRank = function() {
    return this.rank;
};

User.prototype.verifyRank = function(rank) {
    return typeof (rank == Number && rank > 0);
};

User.prototype.setEmail = function(email) {
    if (this.verifyEmail(email)) {
        this.email = email;
        return true;
    }
    return false;
};

User.prototype.getEmail = function() {
    return this.email;
};

User.prototype.verifyEmail = function (email) {
    return true; //TODO finish
};

User.prototype.setState = function (state) {
    this.state = state;
};

User.prototype.getState = function () {
    return this.state;
};

User.prototype.seekingHandler = function(callback) {
    // remove everything for other stages
    this.setState(2);
    callback();
};

User.prototype.acceptedOfferHandler = function(callback) {
    callback();
};

User.prototype.gameStartedHandler = function(callback) {
    callback();
};

User.prototype.checkState = function(callback) {

    if (this.state == 2) {
        // seeking
    } else if (this.state == 3) {
        // accepted offer

    } else if (this.state == 4) {
        // playing
    }

    if (callback) callback();

};

module.exports = User;