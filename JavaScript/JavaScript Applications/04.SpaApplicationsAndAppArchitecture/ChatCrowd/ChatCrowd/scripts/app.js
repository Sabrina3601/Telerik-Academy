(function () {

    $('#log-btn').on('click',function(){
        window.location = "#/chat";
    });
     function sendMessage(resourceUrl, data) {
        return $.ajax({
            url: resourceUrl,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                reloadChat(resourceUrl);
                $('#tb-send').val('');
            },
            error: function (err) {
                console.log(err);
            }
        });
    };

     function reloadChat(resourceUrl) {
        return $.ajax({
            url: resourceUrl,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                var chatters = data;
                var chatlist = $('<ul/>').attr("id", "chat-list");
                for (var i = 0; i < chatters.length; i++) {
                    $('<li />')
                    .append($('<strong/>')
                    .html(chatters[i].by + ':'))
                    .append($('<br/>'))
                    .append($('<span/>')
                    .html(chatters[i].text))
                    .appendTo(chatlist);
                };

                $('#chat-div').html(chatlist);
            },
            error: function (error) {
            }
        });
    };

         var resourceUrl = 'http://crowd-chat.herokuapp.com/posts';
         var app = Sammy('#main-content', function () {
            

            this.get("#/chat", function () {
                var userName = $('#tb-user-name').val() || 'Anonymous';
               
                $('#main-content')
                    .append($('<div />')
                            .attr("id", "chat-div"))
                    .append($('<div />')
                            .attr("id", "send-div")
                            .append($('<input /> ')
                                .attr("type", "text")
                                .attr("maxlength", "70")
                                .attr("id", "tb-send"))
                            .append($('<button />')
                                .attr("id", "send-btn")
                                .html("Send")
                                .on('click', function () {
                                    var message = {
                                        user: userName,
                                        text: $('#tb-send').val()
                                    };
                                    sendMessage(resourceUrl, message);
                                    $("#chat-div").scrollTop($("#chat-div")[0].scrollHeight);
                                })));
                reloadChat(resourceUrl);
                
            });

            this.get("#/about", function () {
                $('#chat-div').remove();
                $('#send-div').remove();
                $('#tb-user-name').remove();
                $('#label-user-name').remove();
                $('#log-btn').remove();
                $('#main-content')
                    .append($('<div />')
                            .attr("id", "about-div")
                            .html("Telerik live chat. Created by<br/> jQuery and Sammy."));
                
            });
        });
        
        
        app.run('#/');


   
}());