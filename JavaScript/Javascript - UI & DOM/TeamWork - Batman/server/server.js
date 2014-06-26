/**
 * Dependencies
 * @type {exports}
 */
var jayson = require('jayson');
var User = require('./lib/user');
var DB = require('./lib/db');
var Player = require('./lib/player');
var Game = require('./lib/game');
var Board = require('./lib/board');


var users = {};

var players = {};
var matches = {};
var games = {};
var garbage = {};
var db = new DB();
var pendingMatches = {};
var offers = {};


var server = jayson.server({
    /**
     * Handle login request
     * @param {string} username
     * @param {string} password
     * @param callback
     */
    login: function (username, password, callback) {
        var $this = this;
        // check if user is already logged in
        //if (users[username]) {
            //callback(null, {res: users[username], err: "User is already logged in."});
            //return;
        //}

        // check credentials
        db.checkCredentials(username, password, function (res) {
            if (!res.res) {
                console.log("Invalid password.");
                callback(null, res);
            } else {
                console.log("User found.");
                // add new user to users online
                db.getUser(username, function(user) {
                    if (!user['err']) {
                        var newUser =
                        users[res.res['username']] = new User(user['username'] ? user['username'] : "",
                            user['password'] ? user['password'] : "",
                            user['rank'] ? user['rank'] : "",
                            user['email'] ? user['email'] : "",
                            user['token'] ? user['token'] : {});
                        users[res.res['username']].setState(1); // user is online
                        var tmp = {};
                        if (!user.hasOwnProperty('res')) tmp = {res: users[res.res['username']], err: false};
                        else tmp = user;
                        callback(null, {res: user, err: false});
                    } else {
                        callback(null, {res: false, err: "Wrong username or password."});
                    }
                });
            }
        });
    },
    /**
     * Handle check cookie request
     * @param {object} cookies
     * @param callback
     */
    checkCookie: function (cookies, callback) {
        var $this = this;
        if (users[Object.keys(cookies)[0]]) {
            /*users[user['username']] = new User(user['username'] ? user['username'] : "",
                user['password'] ? user['password'] : "",
                user['rank'] ? user['rank'] : "",
                user['email'] ? user['email'] : "",
                user['token'] ? user['token'] : {});*/
            console.log("SAVED USER FROM COOKIE: ", users[Object.keys(cookies)[0]]);
            if (users[Object.keys(cookies)[0]]['state']) {
                var state = users[Object.keys(cookies)[0]].getState();
                console.log("SAVED USER FROM COOKIE2: ");
                if (state != 2) {
                    if (users[Object.keys(cookies)[0]].hasOwnProperty('seekedMatch') && users[Object.keys(cookies)[0]]['seekedMatch']) {
                        users[Object.keys(cookies)[0]].setState(1);
                        users[Object.keys(cookies)[0]]['seekedMatch'] = {};
                    }
                    console.log("JUST BEFORE CALLBACK ", users[Object.keys(cookies)[0]]);
                    callback(null, users[Object.keys(cookies)[0]]);
                    return;
                } else if (state == 1) {

                } else if (state == 2) {
                    // seeking
                    users[Object.keys(cookies)[0]].seekingHandler(function () {
                        callback(null, users[Object.keys(cookies)[0]]);
                        return;
                    });
                } else if (state == 3) {
                    // accepted offer
                    users[Object.keys(cookies)[0]].acceptedOfferHandler(function () {
                        callback(null, users[Object.keys(cookies)[0]]);
                        return;
                    });
                } else if (state == 4) {
                    // game started
                    users[Object.keys(cookies)[0]].gameStartedHandler(function () {
                        callback(null, users[Object.keys(cookies)[0]]);
                        return;
                    });
                }
            }
        } else {
            callback(null, {res: false, err: "Could not set user as online."});
        }
    },
    /**
     * Handle register request
     * @param {string} username
     * @param {string} password
     * @param {string} email
     * @param callback
     */
    register: function (username, password, email, callback) {
        var $this = this;

        var newUser = {
            username: username,
            password: password,
            email: email
        };
        console.log("Before", newUser);
        db.register(newUser, function(res) {
            if (!res.res) {
                console.log("Could not register", res.err);
                callback(null, res);
            } else {
                console.log("Registration successful");
                db.getUser(username, function(user) {
                    if (!user.hasOwnProperty('err')) {
                        users[res.res['username']] =  new User(user['username'] ? user['username'] : "",
                            user['password'] ? user['password'] : "",
                            user['rank'] ? user['rank'] : "",
                            user['email'] ? user['email'] : "",
                            res.res['token'] ? res.res['token'] : "");

                        callback(null, {res: users[res.res['username']], err: false});
                    } else {
                        callback(null, {res: false, err: "Username and password must be at least 3 characters long."});
                    }
                });
            }
        });
    },
    /**
     * Handle logout request
     * @param {string} username
     * @param callback
     */
    logout: function (username, callback) {
        var $this =this;

        console.log("users online: ", users);
        console.log("users online2: ", username);
        callback(null, {res: username, err: false});
        return;
    },
    /**
     * Handle refresh lobby request
     * @param {string} username
     * @param callback
     */
    refresh: function (username, callback) {
        console.log("FROM REFRESH: ", username);
        console.log("FROM REFRESH USERS: ", users);

        // check state
        if (users[username]) {
            users[username].checkState(function(res) {

            });
        }

        // Update new seeked matches from user profiles if any
        if (!matches) matches = {};
        for (var u in users) {
            if (users.hasOwnProperty(u) && users[u]) {
                var state = users[u].getState();
                if (state == 2 && users[u].hasOwnProperty('seekedMatch') && users[u]['seekedMatch']) {
                    matches[users[u]['username']] = users[u]['seekedMatch'];
                } else if (state == 3) { // TODO MAYBE FINISH

                }
            }
        }

        console.log("FROM REFRESH OFFERS: ", offers);
        callback(null, {user: users[username], matches: matches, garbage: garbage, offers: offers});
        return;
    },

    seek: function(username, seekedMatch, callback) {
        var $this = this;

        db.createMatch(seekedMatch, function(match) {
            if (match) {
                users[username]['seekedMatch'] = match;
                users[username].setState(2);
                callback(null, match);
                return;
            } else {
                callback(null, false);
                return;
            }
        });
    },

    stopSeeking: function(username, callback) {
        var $this = this;

        db.removeMatch(username, function(res) {
            if (res) {
                users[username].setState(1);
                if (users[username].hasOwnProperty('seekedMatch') && users[username]['seekedMatch']) users[username]['seekedMatch'] = {};
                if (matches[username]) {
                    if (!garbage) garbage = {};
                    garbage[username] = matches[username];
                    delete matches[username];
                }
                callback(null, users[username]);
                return;
            } else {
                callback(null, false);
                return;
            }
        });
    },

    acceptedMatch: function(player1, player2, callback) {
        // Host accepted from notification
        if (offers.hasOwnProperty(player1) && offers[player1]) {
            users[player2].setState(4);
            users[player1].setState(4);
            users[player1]['game'] = {
                player1: {username: player1, rank: users[player1]['rank']},
                player2: {username: player2, rank: users[player2]['rank']},
                match: offers[player1]
            };
            users[player2]['game'] = {
                player1: {username: player1, rank: users[player1]['rank']},
                player2: {username: player2, rank: users[player2]['rank']},
                match: offers[player1]
            };
            callback(null, {player1: users[player1], player2: users[player2]});
            return;
        }

        callback(null, false);
    },

    acceptOffer: function(player1, player2, callback) {
        // if offer exists in offers player2 accepts it(Accept from notification)
       if (matches[player1] && !offers.hasOwnProperty(player1)) { // If matches[player1] exists and offer is not yet in offers[player1]
            console.log("We have that offer ", matches[player1]);
            offers[player1] = matches[player1];
            if (!offers[player1].hasOwnProperty('player1')) offers[player1]['player1'] = {};
            offers[player1]['player1']['username'] = player1;
            offers[player1]['player1']['accepted'] = true;
            offers[player1]['player1']['rank'] = users[player1]['rank'];
            if (!offers[player1].hasOwnProperty('player2')) offers[player1]['player2'] = {};
            offers[player1]['player2']['username'] = player2;
            offers[player1]['player2']['accepted'] = false;
            offers[player1]['player2']['rank'] = users[player2]['rank'];
            offers[player1]['username'] = player1;
            users[player1].setState(3);
            users[player2].setState(3);
            console.log("OFFERS HERE: ", offers);
           console.log("USERS HERE: ", users);
            callback(null, offers[player1]);
        } else {
            callback(null, false);
        }
    },

    startGame: function(player1, player2, callback) {
        var player2State = 4;
        if (users[player1]['game'].hasOwnProperty('id') && users[player1]['game']['id'] && users[player2].hasOwnProperty('id')) player2State = 5;

        // Delete all offers etc. cause game started
        if (users[player1].hasOwnProperty('seekedMatch')) users[player1]['seekedMatch'] = {};
        if (users[player2].hasOwnProperty('seekedMatch')) users[player2]['seekedMatch'] = {};
        if (offers.hasOwnProperty(player1)) delete offers[player1];
        if (offers.hasOwnProperty(player2)) delete offers[player2];
        if (matches.hasOwnProperty(player1)) delete matches[player1];
        if (matches.hasOwnProperty(player2)) delete matches[player2];
        // create game
        // players
        var fPlayer = new Player(player1, 1, 5);
        var sPlayer = new Player(player2, 2, 5);
        // board
        //player1, player2, time, startTime, board
        var board = new Board();
        console.log("DEBUG===============", users[player1]);
        var game = new Game(fPlayer, sPlayer, users[player1]['game']['time'], board);
        users[player1]['game'] = game;
        users[player2]['game'] = game;
        //change stages to 5
        users[player1].setState(5);
        users[player2].setState(player2State);
        // If both players loaded starting position set them in state 6
        if (users[player1]['state'] ==  5 && users[player2]['state'] == 5) {
            users[player1].setState(6);
            users[player2].setState(6);
        }
        callback(null, {player1: users[player1], player2: users[player2]});
        return;
    },

    verifyMove: function(gameId, player, moves, move, callback) {
        for (var i in users) {
            if (users.hasOwnProperty(i)) {
                if (users[i]['game']['id'] == gameId) {
                    // This is the game
                    users[i]['game']['board'].syncMoves(moves, function(res) {
                        if (res) {
                            users[i]['game']['board'].validateMove(move, function(res) {

                            });
                        }
                    });

                }
            }
        }
    },

    /**
     * Ping
     * @param callback
     */
    ping: function(callback) {
        callback(null, "pong");
    }
});

/**
 * Start listening on port 3000
 */
server.http().listen(3000, function () {
    console.log("Listening to 3000");
});