/**
 * Dependencies
 * @type {exports}
 */
var fs = require('fs');

/**
 * Constructor
 * @constructor
 */
var DB = function() {
    this.path = "data/users/";
    this.extension = ".txt";
    this.matchesPath = "data/matches/";
    this.gamesPath = "data/games/";
    this.timeIndecies = {
        1 : 60000,
        2 : 120000,
        3 : 180000,
        4 : 300000,
        5: 600000,
        6: 900000,
        7 : 1800000
    }
};

/**
 * Normalize path to db
 * @param {string} path
 * @returns {string}
 */
DB.prototype.normalizePath = function(path) {
    return this.path + path + this.extension;
};

/**
 * Check if username is free
 * @param {string} username
 * @returns {boolean}
 */
DB.prototype.isTakenUsername = function(username) {
    if (fs.existsSync(this.normalizePath(username))) {
        console.log("User already exists.");
        return true;
    } else  return false;
};

/**
 * Generate token
 * @returns {{token: *, expires: number}}
 */
DB.prototype.generateToken = function() {
    var rand = function () {
        return Math.random().toString(36).substr(2); // remove `0.`
    };
    return { token: rand() + rand(), expires: (new Date()).getTime() + 86400000 };
};

/**
 * Check credentials
 * @param {string} username
 * @param {string} password
 * @param callback
 */
DB.prototype.checkCredentials = function(username, password, callback) {
    console.log(username);
    if (!fs.existsSync(this.normalizePath(username))) {
        console.log("User does not exist.");
        callback({res: false, err: "User does not exist."});
        return;
    }

    var user = JSON.parse(fs.readFileSync(this.normalizePath(username)));
    console.log(user);
    if (user['password'] == password) {
        console.log("Password matches the user");
        if (!user['token'].hasOwnProperty('token') && Object.keys(user['token']).length === 0) user.token = this.generateToken();
        console.log("I AM GOING TO WRITE FILE , ", user);
        this.updateUser(user['username'], user, function() {
            callback({res: user, err: false});
            return;
        });
    } else {
        callback({res: false, err: "Password does not match."});
        return;
    }
};

/**
 * Check cookie
 * @param {object} cookies
 * @param callback
 */
DB.prototype.checkCookie = function (cookies, callback) {
    var allUsers = fs.readdirSync(this.path);
    console.log("ALL USERS: ", allUsers)
    console.log("Cookies object", cookies);
    console.log("Maika", Object.keys(cookies)[0]);
    var username = false;
    var userFound = false;
    var token = false;
    for (var i = 0; i < allUsers.length; i++) {
        var currUser = allUsers[i].replace(".txt", "");
        console.log("Current user: ", currUser);
        console.log("Current cookies user: ", cookies[currUser]);
        if (Object.keys(cookies)[0] == currUser) {
            var user = JSON.parse(fs.readFileSync(this.normalizePath(currUser)));
            console.log("1READ USER ", user['token']['token'])
            console.log("2READ USER ", cookies[currUser])
            if (user['token']['token'] == cookies[currUser]) {
                userFound = true;
                token = cookies[currUser];
            }
        }
    }
    console.log("USER FOUND?", userFound, token);

    if (userFound) {
        if (user['token']['token'] == token) {
            console.log("proverka1", user['token']['expires'])
            console.log("proverka2", (new Date()).getTime());
            console.log("Proverka3 ", user['token']['expires'] > (new Date()).getTime())
            if (user['token']['expires'] > (new Date()).getTime()) {
                callback({res: user, err: false});
                return;
            } else {
                console.log("The users session expired?")
                callback({res: false, err: "User session expired."});
                return;
            }
        } else {
            console.log("The user was not found&&&&")
            callback({res: false, err: "Tokens don't match"});
            return;
        }
    } else {
        console.log("User does not exist.");
        callback({res: false, err: "User does not exist."});
        return;
    }
};

/**
 * Remove cookie
 * @param {string} username
 * @param callback
 */
DB.prototype.removeCookie = function (username, callback) {
    if (!fs.existsSync(this.normalizePath(username))) {
        console.log("User does not exist.");
        callback({res: false, err: "User does not exist."});
        return;
    }

    var user = JSON.parse(fs.readFileSync(this.normalizePath(username)));
    console.log("USER READ123", user);
    user['token'] = {};
    fs.writeFile(this.normalizePath(username), JSON.stringify(user), function(err) {
        if (err) {
            console.log(err);
            callback({res: false, err: "Error writing file."});
        } else {
            console.log("The file was saved!");
            callback({res: user, err: false});
        }
    });
};

/**
 * Validate user data
 * @param {object} user
 * @returns {boolean}
 */
DB.prototype.verifyNewUser = function(user) {
    // TODO MAYBE EXTEND VERIFICATION
    if (user.hasOwnProperty('username') && user['username'].length > 3 &&
        user.hasOwnProperty('password') && user['password'].length > 3 &&
        user['username'].length <= 10 || user['password'] <= 15) {
        return true;
    }
    return false;
};

/**
 * Register new user
 * @param {object} user
 * @param callback
 */
DB.prototype.register = function(user, callback) {
    console.log("BEFORE SAVE1", user);
    if (this.isTakenUsername(user['username'])) {
        console.log("Username is taken.");
        callback({res: false, err: "Username is already taken."});
        return;
    }

    if (!this.verifyNewUser(user)) {
        console.log("Invalid credentials.");
        callback({res: false, err: "Username and password must be 3-10 characters long."});
        return;
    }

    user['rank'] = 1200;
    user['token'] = this.generateToken();
    console.log("BEFORE SAVE", user);
    fs.writeFile(this.normalizePath(user['username']), JSON.stringify(user), function (err) {
        if (err) {
            console.log(err);
            callback({res: false, err: "Error writing file."});
        } else {
            console.log("The file was saved!");
            callback({res:user, err: false});
        }
    });
};

/**
 * Get single user
 * @param {string} username
 * @param callback
 */
DB.prototype.getUser = function(username, callback) {
    if (!fs.existsSync(this.normalizePath(username))) {
        console.log("User does not exist.");
        callback({res: false, err: "User does not exist."});
        return;
    }

    var user = JSON.parse(fs.readFileSync(this.normalizePath(username)));

    callback(user);
};

/**
 * Update user
 * @param {string} username
 * @param {object} newUser
 * @param callback
 */
DB.prototype.updateUser = function(username, newUser, callback) {
    if (!fs.existsSync(this.normalizePath(username))) {
        console.log("User does not exist.");
        callback({res: false, err: "User does not exist."});
        return;
    }

    fs.writeFile(this.normalizePath(username), JSON.stringify(newUser), function (err) {
        if (err) {
            console.log(err);
            callback(false);
        } else {
            console.log("The file was saved!");
            callback(true);
        }
    });
};

DB.prototype.generateMatchId = function(match) {
    if (match.hasOwnProperty('username') && match.hasOwnProperty('time') && match.hasOwnProperty('rankRange')) {
        return match['username'];
    }
    return false;
};

DB.prototype.createMatch = function(match, callback) {
    var id = this.generateMatchId(match);
    var user = JSON.parse(fs.readFileSync(this.normalizePath(match['username'])));
    if (id) {
        match['started-looking'] = (new Date()).getTime();
        match['rank'] = user['rank'] ? user['rank'] : "Unknown";
        match['time'] = this.timeIndecies[match['time']];
        fs.writeFile(this.matchesPath + id + this.extension, JSON.stringify(match), function(err) {
            if (err) {
                console.log(err);
                callback(false);
                return;
            } else {
                console.log("New match has been saved.", match);
                callback(match);
                return;
            }
        });
    }
    return false;
};

/*
    Functions to maybe use later
 */

DB.prototype.removeMatch = function (username, callback) {
    if (!username || !fs.existsSync(this.matchesPath + username + this.extension)) {
        console.log("Match does not exist.");
        callback(false);
        return;
    }

    fs.unlink(this.matchesPath + username + this.extension, function (err) {
        if (err) {
            console.log(err);
            callback(false);
            return;
        }

        console.log("Match removed.");
        callback(true);
        return;
    });
};

DB.prototype.saveGame = function (game, callback) {
    fs.writeFile(this.gamesPath + game['id'] + this.extension, JSON.stringify(game), function (err) {
        if (err) {
            console.log(err);
            callback(false);
            return;
        }
        callback(true);
    });
};

DB.prototype.updateMatch = function (match, callback) {
    if (!match.hasOwnProperty('id') || !fs.existsSync(this.normalizePath(match['id']))) {
        console.log("Match does not exist.");
        callback({res: false, err: "Match does not exist."});
        return;
    }

    fs.writeFile(this.normalizePath(match['id']), JSON.stringify(match), function (err) {
        if (err) {
            console.log(err);
            callback(false);
            return;
        }

        console.log("Match updated");
        callback(true);
        return;
    });
};

DB.prototype.prepareMatch = function (match, callback) {
    var $this = this;
    // get info from /matches
    var matchFile = JSON.parse(fs.readFileSync($this.matchesPath + match['player1']['username'] + $this.extension));
    console.log("MATCH FILE ", matchFile);
    console.log("PARAMETER ", match);
    var game = {};
    if (matchFile) {
        // delete /matches.txt
        $this.removeMatch(match['player1']['username'], function (res) {
            if (!res) {
                console.log("Error deleting match offer");
                callback(false);
                return;
            }
            // create idGame.txt in /games
            game['start-time'] = (new Date()).getTime();
            game['time-per-player'] = match['time'];
            game['max-expire'] = parseInt(match['startTime']) + ($this.timeIndecies[parseInt(match['time'])] * 2);
            game['player1'] = match['player1'];
            game['player2'] = match['player2'];
            game['outcome'] = 0;
            game['id'] = game['player1']['username'] + "vs" + game['player2']['username'];
            console.log("GAME TO BE SAVED ", game);
            $this.saveGame(game, function (res) {
                if (!res) {
                    console.log("ERROR SAVING GAME");
                    callback(false);
                    return;
                }
                callback(game);
            })
        });
    }
};

module.exports = DB;