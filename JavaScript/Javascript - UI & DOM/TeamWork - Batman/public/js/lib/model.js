
function Model() {
    this.board = null;
    this.player = null;
}

Model.prototype.refresh = function(username, callback) {
    var $this = this;

    app.refresh(username, function (res) {
        console.log('REFRESH1 ', controller.ticks, res);
        if (res.err) {
            console.log("ERROR REFRESHING", res.err);
        }

        controller.ticks++;
        if (res.hasOwnProperty('user') && res['user'] && res['user'].hasOwnProperty('state') && res['user']['state']) {
            // check for garbage
            if (res.hasOwnProperty('garbage') && res['garbage']) $this.checkForGarbage(res['garbage']);

            // Check for

            // states
            if (res['user']['state'] == 1) {
                // online
                if (res.hasOwnProperty('matches') && res['matches']) $this.checkForNewMatches(res['matches']);
                controller.changeState(1, res['user']);
                console.log("user is online no changes");
            } else if (res['user']['state'] == 2) {
                // check for accepted offers or new notifications for games
                console.log("user is seeking", res['user']);
                if (res.hasOwnProperty('offers') && res['offers']) {
                    $this.checkOffers(res['offers']);
                    // maybe return
                }
                if (res.hasOwnProperty('matches') && res['matches']) $this.checkForNewMatches(res['matches']);
                controller.changeState(2, res['user']);
            } else if (res['user']['state'] == 3) {
                // Accepted offer state
                if (res.hasOwnProperty('offers') && res['offers']) {
                    console.log("Checking offers, ", res['offers']);
                    $this.checkOffers(res['offers']); // Check if second player accepted
                    console.log("User Accepted offer ", res['user']);
                    controller.changeState(3, res['user']);
                    // maybe return
                }
                return;
            } else if (res['user']['state'] == 4) { // TODO FINISH
                // Pre game
                console.log("==========================STATE IS 4==========================", res);
                // Go to play page and set starting position to canvas
                controller.setStartPosition(res['user']['game'], function() {
                    console.log("==========================Start pos ok==========================", res);
                    // Send request for player state 5 and begin game
                    controller.startGame(res['user']['game']['player1']['username'], res['user']['game']['player2']['username'], function(res) {
                        console.log("Game created", res.player1, res.player2);
                        return;
                    });
                });

                return;
            } else if (res['user']['state'] == 5) {
                console.log("==========================STATE IS 5==========================", res);
                if (res['user']['player1']['username'] == authentication['user']['username']) $this.player = "player1";
                if (res['user']['player2']['username'] == authentication['user']['username']) $this.player = "player2";
            } else if(res['user']['state'] == 6) {
                console.log("======================================Entered state 6======================================");
                // check for moves not shown yet
                controller.onMove(res['user']['game'], function() {
                    if (res['user']['game']['playersTurn'] == authentication['user']['username']) {
                        // It is my turn
                        console.log("It's my turn...");
                    } else {
                        // its opponent's turn
                        console.log("Waiting for opponents turn...");
                    }
                });
            }
        }
        callback(res['user']);
        return;
    });
};

Model.prototype.checkForGarbage = function(garbage) {
    for (var i in garbage) {
        if (garbage.hasOwnProperty(i)) {
            if ($('.active-games .row' + garbage[i]['username'])) {
                controller.removeMatchRow(garbage[i]['username']);
            }
        }
    }
};

Model.prototype.seek = function (username, seekedMatch, callback) {
    var $this = this;

    app.seek(username, seekedMatch, function (match) {
        if (!match) {
            console.log("Seeking failed.", match);
            ui.showError("Error");
            callback(false);
            return;
        } else {
            console.log("Seeking OK", match);
            // Show new match row if not already exist
            if (!$('.active-game .row.' + match['username']).length) {
                controller.generateNewMatchRow(match);
            }
            callback(true);
            return;
        }
    });
};

Model.prototype.stopSeeking = function(username, callback) {
    var $this = this;

    app.stopSeeking(username, function (res) {
        if (res) {
           console.log("Stopped seeking", res);
           if (callback) callback(res);
        }
    });
};

Model.prototype.checkOffers = function(offers) {
    console.log("Inside checking offers", offers);
    for (var i in offers) {
        if (offers.hasOwnProperty(i)) {
            // if username is mine check if accepted
            if (offers[i].hasOwnProperty('player1') && offers[i]['player1'].hasOwnProperty('username') && offers[i]['player1']['username'] == authentication.user['username']) {
                if (offers[i]['player2'].hasOwnProperty('accepted') && offers[i]['player2']['accepted']) {
                    // accepted offer
                    // start game
                    console.log("I am the host and player2 accepted", offers);
                    console.log("Starting game.");

                    return;
                } else {
                    if (!$('.offers .' + offers[i]['player2']['username']).length) {
                        console.log("showing notifications", offers[i]);
                        ui.prepareOffers(offers[i], function () {
                            ui.addOffer(offers[i]);
                            console.log("Offer shown", offers[i]);
                            //$this.offers[offer['username']] = offer;
                        });
                    }
                }
            } else {
                // if username is different I am not the host
                if (offers[i].hasOwnProperty('player2') && offers[i]['player2']['username'] == authentication.user['username'] && offers[i]['player2'].hasOwnProperty('accepted') && offers[i]['player2']['accepted']) {
                    // check if you have accepted the offer
                    if (offers[i]['player1'][i].hasOwnProperty('accepted') && offers[i]['player1'][i]['accepted']) {
                        console.log("I am player2 both players accepted.");

                    }

                    // if not accepted show notification if not shown already
                    console.log("Check if offers is shown as notification.");
                    if (!$('.offers .' + offers[i]['username']).length) {
                        console.log("showing notifications", offers[i]);
                        ui.prepareOffers(offers[i], function () {
                            ui.addOffer(offers[i]);
                            console.log("Offer shown", offers[i]);
                            //$this.offers[offer['username']] = offer;
                        });
                    }
                }
            }
        }
    }
};

Model.prototype.checkForNewMatches = function (matches) {
    // check for new matches and update lobby
    console.log("New matches: ", matches);
    for (var i in matches) {
        if (matches.hasOwnProperty(i)) {
            if (!$('.active-games .row.' + matches[i]['username']).length) {
                controller.generateNewMatchRow(matches[i]);
            }
        }
    }
};

Model.prototype.setBoard = function(board, callback) {
    if (!this.board) this.board = new Board(board.player1, board.player2, board.time);
    this.board.init(function() {
        callback();
    });
};

Model.prototype.sendAcceptMatch = function(player1, player2, callback) {
    var $this = this;

    app.acceptOffer(player1, player2, function (res) {
        console.log("offer accepted", res);
        if (callback) callback(res);
        /*if (res) {
            //$this.offers[username] = res;
            var match = {
                player1: username,
                player2: authentication['user']['username'],
                time: parseInt($('.active-games .row.' + username + ' .player-time').text())
            };
            console.log("MATCH ACCEPTED HERE LOOK", match);
            app.sendGameRequest(match, authentication['user']['username'], function (res) {
                if (res) {
                    console.log("Game request send");
                    app.setPlayerState(username, 4, function () { // ready state
                        console.log("Player state set...");
                        // wait for other player
                    });
                } else {
                    console.log("Bad game request.");
                }
            });
        }*/
    });
};


