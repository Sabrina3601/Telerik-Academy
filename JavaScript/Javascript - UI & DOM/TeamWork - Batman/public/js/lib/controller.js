/**
    Dependencies
 */

/**
 * Constructor
 * @constructor
 */
function Controller() {
    this.user = {};
    this.ticks = 0;
    this.intervId = 0;
}

/**
 * Login
 */
Controller.prototype.login = function() {
    var $this = this;

    var username = $('.login-username').val().trim();
    var password = $('.login-password').val().trim();

    authentication.login(username, password, function(res) {
        $this.user = res;
        $this.setRefreshInterval(username);
    });
};

/**
 * Register
 */
Controller.prototype.register = function () {
    var $this = this;

    var user = {
        username: $('.register-username').val().trim(),
        password: $('.register-password').val().trim(),
        email: $('.register-email').val().trim()
    };

    authentication.register(user, function (res) {
        $this.user = res;
        $this.setRefreshInterval(user['username']);
    });
};

/**
 * Check session
 * @param {object} cookies
 */
Controller.prototype.checkSession = function (cookies) {
    var $this = this;

    authentication.checkSession(cookies, function (res) {

        console.log("RESPONSE FROM CHECK SESSION: ", res);
        $this.user = res;
        $('.login-box').removeClass("active");
        $('.register-box').removeClass("active");
        ui.showLoggedIn(res['username'], res['rank']);
        ui.showDropdown(null, true);
        ui.changePage('lobby', res['username']);
        $this.user = res;
        $this.setRefreshInterval(res['username']);
    });
};

/**
 * Logout
 */
Controller.prototype.logout = function () {
    authentication.logout();
};

Controller.prototype.setRefreshInterval = function(username) {
    var $this = this;

    console.log("starting refresh");
    $this.intervId = setInterval((function () {
        // Check if interval should be over
        if ($this.ticks > 1000) { // TODO CHANGE THIS
            clearInterval($this.intervId);
            return;
        }

        console.log("starting Interval");
        model.refresh(username, function (user) {
            this.user = user;
        });
    }), 1000);
};

Controller.prototype.changeState = function(state, user) {
    // change state if not already set
    if (!this.intervId) {
        this.setRefreshInterval();
        return;
    }
    if (state == 1) {
        this.user = user;
        console.log("ON CHANGE STATE SAVING THIS USER: ", this.user);
        if (this.user && this.user.hasOwnProperty('seekedMatch')) this.user['seekedMatch'] = {};
        ui.changeState(1, this.user['username']);
    } else if (state == 2) {
        this.user = user;
        console.log("user from change state callback", user);
        if (!$('.active-games .row.' + user['username']).length) {
            if (user.hasOwnProperty('seekedMatch')) this.generateNewMatchRow(user['seekedMatch']);
        }
        ui.changeState(2, user['username']);
    } else if (state == 3) {


    } else if (state == 4) {

    } else if (state == 5) {

    }
};

Controller.prototype.sendAcceptMatch = function(player1) {
    if (this.user['username'] == player1) {
        // cannot start game with yourself
        alert("bla");
        return;
    }

    model.sendAcceptMatch(player1, this.user['username'],  function (res) {
        if (res) {
            console.log("match accepted", res);

        }
    });
};

Controller.prototype.seek = function() {
    var $this = this;

    if (!authentication['user']['username']) {
        alert("please log in.");
    }
    var rankRange = {min: 1200, max: 2400};
    var rankSplit = ($('#amount').val()).split(" - ");
    if (rankSplit.length == 2) {
        rankRange.min = rankSplit[0];
        rankRange.max = rankSplit[1];
    }

    this.user['seekedMatch'] = {
        time: $('.time-range option:selected').val(),
        rankRange: rankRange,
        username: authentication['user']['username']
    };
    console.log("GOING TO SEEK MATCH: ", this.user['seekedMatch']);

    model.seek(this.user['seekedMatch']['username'], this.user['seekedMatch'], function(res) {
        // On callback true change state if not changed already
        if (res && $this.user['state'] != 2) {
            $this.changeState(2, $this.user);
        }
    });
};

Controller.prototype.stopSeeking = function() {
    var $this = this;

    console.log("Stopping seeking ");
    model.stopSeeking(this.user['username'], function(user) {
        // change state to 1
        console.log("Existing user: ", $this.user);
        console.log("user from callback: ", user);
        $this.changeState(1, user);
    });
};

Controller.prototype.generateNewMatchRow = function(match, callback) {
    console.log("77", match);
   //if (Object.keys(this.seekedMatch).length  && this.seekedMatch.rankRange.max > match.rankRange.min && this.seekedMatch.rankRange.min < match.rankRange.max) { // TODO RANK RANGE
   //}

    var rows = $('.active-games .row');
    var oddOrEven = (rows.length && rows.length % 2 == 0) ? "even" : "odd";
    var time = match.time / 60000;
    match.time = time;
    var row = {
        username: match['username'],
        oddOrEven: oddOrEven,
        time: time,
        match: match
    };
    console.log("55", row);
    ui.updateMatchesTable(row);
};

Controller.prototype.removeMatchRow = function(username) {
    ui.removeMatchRows(username);
};

Controller.prototype.stopInterval = function() {
    clearInterval(this.intervId);
    this.intervId = null;
};

Controller.prototype.offerAccept = function(username) {
    // get accepted offer
    if (username == authentication['user']['username']) {
        console.log("Cannot accept your own game.");
        return;
    }

    console.log("GOING TO ACCEPT OFFER ", username, authentication['user']['username']);

    app.acceptedMatch(authentication['user']['username'], username, function(res) {
        if (res) {
            console.log("Both player accepted.", res.player1, res.player2);
        } else {
            console.log("Error on offer accept");
        }
    });
};

Controller.prototype.startGame = function (player1, player2, callback) {
    app.startGame(player1, player2, function (res) {
        if (res) {
            callback(res);
        }
    });
};

Controller.prototype.onMove = function(game, callback) {
    // Check if all moves are up to date
    board.syncMoves(game, function(moves) {
        if (moves) {
            // we have not-show moves
            for (var m in moves) {
                if (moves.hasOwnProperty(m)) board.move(moves[m]);
            }
        }
        callback();
    });
};

Controller.prototype.setStartPosition = function(res, callback) {
    // Show play page
    ui.changeState(4);
    // Initialize board
    var board = {
        player1: {username: res['player1']['username'], rank: res['player1']['rank']},
        player2: {username: res['player2']['username'], rank: res['player2']['rank']},
        time: res['time']
    };

    model.setBoard(board, function(res) {
        callback();
    });
};

Controller.prototype.offerDecline = function (button) {
    // get declined offer
    // send request to server
    // on callback remove offer
    // if there are no more offers remove offers div
};

/**
 * Ping
 */
Controller.prototype.ping = function(callback) {
    app.ping(function(res) {
        if (res) callback(true);
        else callback(false);
    });
};
