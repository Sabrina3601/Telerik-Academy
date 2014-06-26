

function Authentication() {
    this.user = {
        username: "",
        password: "",
        email: "",
        token: "",
        rank: 0
    };
}

/**
 * Login
 */
Authentication.prototype.login = function (username, password, callback) {
    var $this = this;

    app.login(username, password, function (res) {
        console.log("Login finished1");
        console.log("result was: ", res);
        if (res.err) {
            console.log("Login failed.");
            ui.showError(res.err);
        } else {
            console.log("Look here: ", res);
            console.log("1", res.res['token']);
            console.log("2", res.res['token']['token']);

            $.cookie(username, res.res['token']['token'], {expires: 1});
            $this.saveUser(res.res);

            ui.showLoggedIn(res.res['username'], res.res['rank']);
            ui.showDropdown();
            ui.changePage('lobby', res['res']['username']);

            callback(res.res);
            return;
        }
    });
};

Authentication.prototype.register = function(user, callback) {
    var $this = this;

    app.register(user, function (res) {
        if (res.err) {
            console.log("Registration failed.", res.err);
            ui.showError(res.err);
        } else {
            console.log("Registration OK", res);


            $.cookie(res.res['username'], res.res['token']['token']);
            $this.saveUser(res.res);
            ui.showDropdown(true);
            ui.showLoggedIn(res.res['username'], res.res['rank']);
            ui.changePage('lobby', res['res']['username']);
            callback();
            return;
        }
    });
};

Authentication.prototype.checkSession = function(cookies, callback) {
    var $this = this;

    if (Object.keys(cookies).length > 0) {
        app.checkCookie(cookies, function (res) {
            console.log("here", res);
            if (res.err) {
                $this.logout();
                return;
            } else {
                console.log("=========user has cookie============");
                $this.saveUser(res);
                callback(res);
                return;
            }
        });
    } else {
        // user doesn't have a session
        $this.logout();
        return;
    }
};

Authentication.prototype.logout = function(callback) {
    var $this = this;

    app.logout(this.user['username'], function (res) {
        if (res.err) {
            console.log("Logout failed.", res.err);
            ui.showError(res.err);
        } else {
            console.log("Logout OK", res);
            $.removeCookie(res.res);
            console.log("cookies", $.cookie());
            ui.showLoggedOut();
            controller.stopInterval();
        }
    });
};

Authentication.prototype.saveUser = function(res) {
    if (!this.user) this.user = {};
    console.log("user to be saved1: ", res);
    this.user['username'] = res['username'];
    this.user['password'] = res['password'];
    this.user['token'] = res['token'];
    this.user['rank'] = res['rank'];
    this.user['email'] = res['email'];
};