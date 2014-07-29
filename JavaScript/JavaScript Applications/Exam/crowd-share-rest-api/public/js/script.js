/// <reference path="jquery-2.1.1.min.js"/>
var serviceUrl = 'http://jsapps.bgcoder.com/';

$('#view-posts').on('click', function () {
    $('section').html('<h2 id="total-posts">Last 100 posts:</h2>');
    var divPosts = '<div id="posts"></div>';
    $('section').append(divPosts);
    reloadPosts();
});



function onSuccessPost() {
    var message = '<p> You post was successful </p>';

    var postFade = $('section').html(message).css("display", "none");
}
/// reload postst
function reloadPosts() {
    getFunction(serviceUrl + "post", getPostsSuccess, onErrorSuccess);
 }
reloadPosts();

function onErrorSuccess() {
    console.log("error");
}

function getPostsSuccess(data){
    var totalPosts = data.length;
    var $postsContainer = $('#posts');

    for (var i = 0; i < totalPosts; i++) {
        var currentPost = data[i];
        var well = $('<div />').addClass('well')
        .text(currentPost.title + ': "' + currentPost.body + '" by ' + currentPost.user.username).appendTo('#posts');
    }
}



/// start registration

$('#reg').on('click', regClick);

function regClick(event) {
    // myPreventDefault(event);
    var regForm = '<form id="signup-form">' +
       '<label for="username">Username</label></br>' +
       '<input id="username" type="text"/>' +
       '<label id="name-validation"></label>' +
       '</br><label for="password">Passwod</label></br>' +
       '<input id="password" type="password"/>' +
       '<label id="pass-error"></label>'+
       '</br><label for="password_confirm">Repeat Password</label></br>' +
       '<input id="password-confirm" type="password"/>' +
       '<label id="repeat-pass-error"></label></br>' + 
       '<button id="registration-btn">Register</button></br>'+
       '</form>';
    
    var registarFade = $('section').html(regForm).css("display", "none");
    $(registarFade).fadeIn(500);
        
    $("#registration-btn").on("click", validateReg);
}

function validateReg(event) {
    //myPreventDefault(event);
    $("#name-validation").html("");
    $("#pass-error").html("");
    var name = $("#username").val();
    var pass = $("#password").val();
    var repeatPass = $("#password-confirm").val();
    if (name.length < 6) {
        $("#name-validation").html("Username must be atleast 4 characters");
    }
    if (pass.length < 6) {
        $("#pass-error").html("Password must be atleast 4 characters");
    }
    if (pass != repeatPass) {
        $("#repeat-pass-error").html("Password does not match");
    }
    if (name.length >= 6 && pass.length >=6 && pass == repeatPass) {
        submitReg(name, pass);
    };

}
function submitReg(name, pass) {


    

    var body = {
        username: name,
        authCode: CryptoJS.SHA1(name + pass).toString()
    };

    postFunction(serviceUrl + "user",
    body,
    onUserRegisterSuccess, onErrorSuccess);
}

function onUserRegisterSuccess(data) {
    //alert("User Registered!");
    var registerSuccess = '<div id="register-success">User Registered!</div>';
    $("section").append(registerSuccess);
    var name = $("#username").val();
    var pass = $("#password").val();
    setTimeout(loginFunc(name, pass),10000)
    //loginFunc(name, pass);
    //$('section').dialog({
    //    modal: true,
    //    buttons: {
    //        Ok: function () {
    //            $(this).dialog("close");
    //        }
    //    }
    //});
    // login

}
///////////// end registration




/// start login
$('#login').on('click', login);

function login() {
    var regForm = '<form id="signup-form">' +
       '<label for="username">Username</label></br>' +
       '<input id="username" type="text"/>' +
       '<label id="name-validation"></label>' +
       '</br><label for="password">Passwod</label></br>' +
       '<input id="password" type="password"/>' +
       '<label id="pass-error"></label>' +
       '<button id="login-btn">Login</button></br>' +
       '</form>';

    var registarFade = $('section').html(regForm).css("display", "none");
    $(registarFade).fadeIn(500);

    var name = $('#username').val();
    var pass = $('#password').val();
    $("#login-btn").on("click", validateLogin);
}

function validateLogin() {
    $("#name-validation").html("");
    $("#pass-error").html("");
    var name = $("#username").val();
    var pass = $("#password").val();

    if (name.length < 6) {
        $("#name-validation").html("Username must be atleast 4 characters");
    }
    if (pass.length < 6) {
        $("#pass-error").html("Password must be atleast 4 characters");
    }
    if (name.length >= 6 && pass.length >= 6) {
        loginFunc(name, pass);
    };
}
function loginFunc(name,pass) {
    var body = {
        username: name,
        authCode: CryptoJS.SHA1(name + pass).toString()
    };

    postFunction(serviceUrl + "auth",
    body,
    onUserLogin, onErrorSuccess);
}

function onUserLogin(data) {
    var key = (data['sessionKey']);
    console.log(key);
    $('#signup-form').remove;
    var registerSuccess = '<h3>Login is successfull!</h3>';
    $("section").html(registerSuccess);
    var logout = '<li id="logout"><a href="#">Logout</a></li>';
    $('#navigation').append(logout);
    $('#logout').on('click', function () {
      //  var sessionName = localStorage.getItem('name');
        var seesionKey = localStorage.getItem('sessionKey');
        console.log(seesionKey);
        //for (var i = 0; i < localStorage.length; i++) {
        //    var key = localStorage.key(i);
        //    seesionKey = localStorage.getItem(key)
        //}

        console.log(localStorage.getItem(seesionKey));




        $.ajax({
            url: 'http://jsapps.bgcoder.com/user',
            headers: { 'X-SessionKey': seesionKey },
            type: "PUT",
            timeout: 5000,
            contentType: "application/json",
            dataType: "json",
            success: function () {
                var message = '<h2> You logout succsessfull </h2>';

                var postFade = $('section').html(message).css("display", "none");
                postFade.fadeIn(500);
                $('#logout').remove();
                reloadPosts();
            },
            error: onErrorSuccess
        });
    })
    
    localStorage.setItem('sessionKey', key);
    localStorage.setItem('name', data['username'])
    makePost();
    
}
//search
$('#search-btn').on('click', function () {
    var search = $('#text-search').val();
    getFunction(serviceUrl + "post?user=" + search, searchSuccessOn,onErrorSuccess)
})
function searchSuccessOn(data) {
    var totalPosts = data.length;
    var $postsContainer = $('<div/>');

    for (var i = 0; i < totalPosts; i++) {
        var currentPost = data[i];
        var well = $('<div />').addClass('well')
        .text(currentPost.title + ': "' + currentPost.body + '" by ' + currentPost.user.username);
        $postsContainer.append(well);
    }
    $('section').html($postsContainer);
}

// search by content
$('#loren-search').on('click', function () {
    var search = $('#text-search').val();
    getFunction(serviceUrl + "post?pattern=" + search, searchSuccessOn, onErrorSuccess)
})
function searchSuccessOn(data) {
    var totalPosts = data.length;
    var $postsContainer = $('<div/>');

    for (var i = 0; i < totalPosts; i++) {
        var currentPost = data[i];
        var well = $('<div />').addClass('well')
        .text(currentPost.title + ': "' + currentPost.body + '" by ' + currentPost.user.username);
        $postsContainer.append(well);
    }
    $('section').html($postsContainer);
}


/// make posts
function makePost() {
    var postForm = '<button id="make-post">Create Post</button>';
    var logout = '<button id="logout">Logout</button>';


    var registarFade = $('section').html(postForm).append(logout).css("display", "none");
    $(registarFade).fadeIn(500);


    $('#make-post').on('click', function () {


        var input = '<input type="text" id="title-post"/>';
        var textArea = '<textarea id="textArea" rows="4" cols="50"></textarea>';
        var button = '<button id="post-btn">Post</button>'

        var postFade = $('section').html(input).append(textArea).append(button).css("display", "none");
        $(registarFade).fadeIn(500);

        $('#post-btn').on('click', function () {
            var titlePost = $('#title-post').val();
            var contentPost = $('#textArea').val();
            var seesionKey = localStorage.getItem('sessionKey');
            //for (var i = 0; i < localStorage.length; i++) {
            //    var key = localStorage.key(i);
            //    seesionKey = localStorage.getItem(key)
            //}

            console.log(localStorage.getItem(seesionKey));
            var body = {
                title: titlePost,
                body: contentPost
            };

            

            $.ajax({
                url: 'http://jsapps.bgcoder.com/post',
                headers: { 'X-SessionKey': seesionKey },
                type: "POST",
                timeout: 5000,
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(body),
                success: function () {
                    var message = '<h2> You post was successful </h2>';

                    var postFade = $('section').html(message).css("display", "none");
                    postFade.fadeIn(500);
                    reloadPosts();
                },
                error: onErrorSuccess
            });
            
        })




    })

}

//////// end login


function getFunction(serviceUrl, onSuccess, onError) {
    $.ajax({
        url: serviceUrl,
        type: "GET",
        timeout: 5000,
        dataType: "JSON",
        success: onSuccess,
        error: onError
    });
}

function postFunction(serviceUrl, data, onSuccess, onError) {
    $.support.cors = true;
    $.ajax({
        url: serviceUrl,
        type: "POST",
        timeout: 5000,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data),
        success: onSuccess,
        error: onError
    });
}