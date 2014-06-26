/*
    UI
 */

/**
 * Constructor
 * @constructor
 */
function UI() {}

/**
 * Change page
 * @param {string} page
 */
UI.prototype.changePage = function(page, username) {
    $('.page.opened').removeClass('opened');
    $('.page.active').removeClass('active');
    $('.page.active').removeClass('opened');
    $("." + page).addClass('opened');
    if (page == 'lobby') {

    }
};

UI.prototype.startGame = function(game, callback) {
    // make lobby invisible
    this.changePage('game');
    // load canvas and set start position

};

UI.prototype.updateMatchesTable = function(row) {
    console.log("66 UI", row);
    var html = "" +
        "<div class='row " + row.oddOrEven + " " + row['username'] + "' onclick=\"controller.sendAcceptMatch('" + row['username'] +"'); return false;\">" + "<div class='action'></div>" +
        "<div class='player-name'>" + row.match.username +
        "</div><div class='player-rating'>" + row.match.rank + "</div>" +
        "<div class='player-time'>" + row.match.time + " min</div>" +
        "</div><div class='clear'></div>";
    console.log("HTML ", html);
    $('.active-games').append(html);
};

UI.prototype.removeMatchRows = function(match) {
    console.log("========================REMOVING================================", match);
    var row = $('.active-games .row .player-name:contains("' + match['username'] + '")');
    if (row) {
        if ($(row).text() == match['username']) {
            console.log("========================REMOVING================================", match);
            $(row).parent().remove();
        }
    }
};

UI.prototype.changeState = function(seeking, username) {
    console.log("====================CHANGING STATES====================", seeking);
    var seekButton = $('.seek');
    if (seeking) {
        seekButton.html("Stop");
        return;
    }
    seekButton.html("Seek");
    $('.active-games .row .player-name:contains("' + username + '")').parent().remove();
};

UI.prototype.prepareOffers = function(offer, callback) {
    // set game-offers visible if not already
    var offersBox = $(".game-offers");
    if (offersBox.hasClass('active')) {
        this.addOffer(offer, function() {
            offersBox.animate({top: '70'}, 'slow', function () {

            });
        });
    } else {
        offersBox.addClass('active');
        offersBox.attr('display', 'block');
        offersBox.animate({top: '70'}, 'slow', function() {

        });
    }

    if (callback) callback();
};

UI.prototype.addOffer = function(offer, callback) {
    /*
     <li class="offer convictt">
        <span class="offer-username">Convictt</span>(<span class="offer-rank">1200</span>)<br>
        Time: <span class="time">5:00</span><br>
        <button class="offer-accept" onclick="controller.offerAccept(this); return false;">Accept</button>
        <button class="offer-decline" onclick="controller.offerDecline(this); return false;">Decline</button>
     </li>
     */
    var html = '' +
        '<li class="offer ' + offer['username'] + '"><span class="offer-username">' + offer['username'] + '</span>(<span class="offer-rank">' + offer['rank'] + '</span>)<br>' +
            'Time: <span class="time">' + offer['time'] + '</span><br>' +
            '<button class="offer-accept" onclick="controller.offerAccept(\'' + offer["username"].trim() + '\'); return false;">Accept</button>' +
            '<button class="offer-decline" onclick="controller.offerDecline(\"' + offer["username"].trim() + '\"); return false;">Decline</button>' +
        '</li>';

    $('.offers').append(html);
    if (callback) callback();
};

/**
 * Show error on login or register
 * @param {string} err
 */
UI.prototype.showError = function(err) {
    var errorBox = $('.error');
    $('.error-message').text(err);
    errorBox.show('slow');
    setTimeout(function() {
        errorBox.hide('slow');
    }, 4000);
};

/**
 * Handle show/hide drop down with login or register
 * @param {boolean} loggedIn
 * @param {boolean} refresh
 */
UI.prototype.showDropdown = function(loggedIn, refresh) {
    var button = $('.header .middle .menu h2');

    if (button.text('Login') == "Logout") {
        this.showLoggedOut();
    } else {
        button.text('Login');
        var loginBox = $('.menu .login-box');
        var registerBox = $('.menu .register-box');
        if (loginBox.hasClass('active') || registerBox.hasClass('active')) {
            if (!loginBox.hasClass('active') && registerBox.hasClass('active')) {
                console.log("show1");
                registerBox.removeClass('active');
                registerBox.hide();
                loginBox.addClass('active');
                if (!loggedIn) loginBox.show();
            } else {
                console.log("hide1");
                $('.menu div.active').removeClass('active');
                loginBox.hide();
                registerBox.hide();
            }
        } else {
            if (refresh) return;
            console.log("show");
            loginBox.addClass('active');
            loginBox.show();
        }
    }
};

/**
 * Hide drop-down
 */
UI.prototype.hideDropdown = function() {
    var login = $('.login-box');
    var register = $('.register-box');
    login.removeClass('active');
    register.removeClass('active');
    login.hide();
    register.hide();
};

/**
 * Show register box
 */
UI.prototype.showRegister = function() {
    $('.header .middle .menu h2').text('Register');
    $('.header .middle .menu .login-box').removeClass("active");
    $('.menu .login-box').hide();
    $('.header .middle .menu .register-box').addClass("active");
    $('.menu .register-box').show();
};

/**
 * Change ui after logged in
 * @param {string} username
 * @param {string} rank
 */
UI.prototype.showLoggedIn = function(username, rank) {
    $('.logged-in').removeClass("logged-in");
    var dropDown = $('.dropdown');
    dropDown.text('Logout');
    dropDown.attr('onclick', 'controller.logout(); return false;');
    $('.header-user').text(username);
    $('.header-rank').text(rank);
};

/**
 * Change ui after logged out
 */
UI.prototype.showLoggedOut = function() {

    for(var i = 1; i <= 4; i++) {
        $('.menu li:nth-child(' + i + ')').addClass("logged-in");
    }
    var dropDown = $('.dropdown');
    dropDown.text('Login');
    dropDown.attr('onclick', 'ui.showDropdown(); return false;');
    $('.login-box').removeClass('active');
    $('.register-box').removeClass('active');
    $('.page.opened').removeClass('opened');
    $('.page .login').addClass('opened');
};

/**
 * Change row states in lobby
 * @param {string} row
 */
UI.prototype.changeRowState = function (row) {
    var icon = $(row + " i ");
    if (icon.hasClass('play')) {
        icon.removeClass('play');
        icon.addClass('stop');
    } else {
        icon.removeClass('stop');
        icon.addClass('play');
    }
};