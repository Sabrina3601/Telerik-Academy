/**
 * Constructor
 * @constructor
 */
var App = function() {
    this.client = null;
};

/**
 * Create RPC client
 */
App.prototype.connect = function() {
    if (!this.client) {
        this.client = new $.JsonRpcClient({
            ajaxUrl: 'http://127.0.0.1:3000'
        });
    }
};

/**
 * Send login request
 * @param {string} username
 * @param {string} password
 * @param callback
 */
App.prototype.login = function(username, password, callback) {
    if (this.client == null) this.connect();

    this.client.call(
        'login', [username, password],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

/**
 * Send check cookie request
 * @param {object} cookies
 * @param callback
 */
App.prototype.checkCookie = function (cookies, callback) {
    if (this.client == null) this.connect();

    this.client.call(
        'checkCookie', [cookies],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

/**
 * Send register request
 * @param {object} user
 * @param callback
 */
App.prototype.register = function(user, callback) {
    if (this.client == null) this.connect();
    console.log("BEFORE BEFORE ", user);
    this.client.call(
        'register', [user['username'], user['password'], user['email']],
        function (result) {
            console.log("The error is ", result);
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

/**
 * Send logout request
 * @param {string} username
 * @param callback
 */
App.prototype.logout = function(username, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN", username);
    this.client.call(
        'logout', [username],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

/**
 * Send initialize lobby request
 * @param {string} username
 * @param callback
 */
App.prototype.refresh = function(username, callback) {
    if (this.client == null) this.connect();
    //console.log("LOOK HERE MEAN2", username);
    this.client.call(
        'refresh', [username],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.seek = function(username, seekedMatch, callback) {
    if (this.client == null) this.connect();
    console.log("SEEKING", username, seekedMatch);
    this.client.call(
        'seek', [username, seekedMatch],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.stopSeeking = function(username, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN4", username);
    this.client.call(
        'stopSeeking', [username],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.acceptOffer = function (player1, player2, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN6", player1, player2);
    this.client.call(
        'acceptOffer', [player1, player2],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.acceptedMatch = function (player1, player2, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN7", player1, player2);
    this.client.call(
        'acceptedMatch', [player1, player2],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.offerAccept = function(player1, player2, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN7", player1, player2);
    this.client.call(
        'acceptedMatch', [player1, player2],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.startGame = function (player1, player2, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN7", player1, player2);
    this.client.call(
        'startGame', [player1, player2],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

App.prototype.verifyMove = function (gameId, player, moves, move, callback) {
    if (this.client == null) this.connect();
    console.log("LOOK HERE MEAN7", player1, player2, gameId, player, moves, move);
    this.client.call(
        'acceptedMatch', [gameId, player, moves, move],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};

/**
 * Send ping request
 * @param callback
 */
App.prototype.ping = function(callback) {
    if (this.client == null) this.connect();

    this.client.call(
        'ping', [],
        function (result) {
            callback(result);
            return;
        },
        function (err) {
            console.log("ERROR", err);
            callback(err);
            return;
        }
    )
};