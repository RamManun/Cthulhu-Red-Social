$(function () {

    // Ссылка на автоматически-сгенерированный прокси хаба
    var chat = $.connection.dialogHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    chat.client.addMessage = function (msg) {
        // Добавление сообщений на веб-страницу
        $('#new_message_place').append(msg.name + " : " + msg.text);
    };

        // обработка логина   
    $.connection.hub.start().done(function () {
        $("#messageSubmit").click(function () {
            var msg = {
                'name': $.browser.version,
                'text': $('#Content').val()
            };
            chat.server.send(msg);
        });
    })

});