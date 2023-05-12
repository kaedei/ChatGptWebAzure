$(document).ready(function () {
    var chatHistory = JSON.parse(localStorage.getItem("chatHistory")) || [];
    displayChatHistory();

    $(".spinner-border").hide();

    // 当用户提交表单时，向ChatGPT发送问题并获取回答
    $("#chat-form").submit(function (event) {
        event.preventDefault();
        var userMessage = $("#user-message").val();
        $("#user-message").val("");

        // 添加一个加载器来冻结页面
        $(".spinner-border").show();

        // 将用户的消息和之前的对话历史记录附加到请求中
        chatHistory.push({ role: "user", content: userMessage });
        displayChatHistory();

        var requestData = {
            prompt: chatHistory,
            temperature: 0.7,
            max_tokens: 1200
        };

        $.ajax({
            url: "/v1/chat/completions",
            headers: {
                "Content-Type": "application/json"
            },
            method: "POST",
            data: JSON.stringify(requestData),
            success: function (data) {
                var botMessage = data.choices[0].message.content.trim();
                chatHistory.push({ role: "assistant", content: botMessage });
                displayChatHistory();
            },
            complete: function () {
                // 隐藏加载器
                $(".spinner-border").hide();
            }
        });
    });


    // 将聊天历史记录添加到聊天框中
    function displayChatHistory() {
        $("#chat-box").empty();
        if (chatHistory.length === 0) {
            // 如果历史消息是空的，显示默认欢迎语
            chatHistory.push({ role: "assistant", content: "欢迎使用 ChatGPT，您现在可以向我提问了。" });
        }
        for (var i = 0; i < chatHistory.length; i++) {
            var message = chatHistory[i];
            var messageHTML = "<div class='" + message.role + "-message'>";
            if (message.role === "user") {
                messageHTML += "<div class='message-text'>" + message.content + "</div>";
                messageHTML += "<div class='user-avatar'></div>";
            } else {
                messageHTML += "<div class='bot-avatar'></div>";
                messageHTML += "<div class='message-text'>" + message.content + "</div>";
                //messageHTML += "<div class='copy-button' onclick='onClickCopy(event)'>Copy</div>";
            }
            messageHTML += "</div>"
            $("#chat-box").append(messageHTML);
        }

        //保存到localStorage
        localStorage.setItem("chatHistory", JSON.stringify(chatHistory));

        // 滚动到最新的一条消息
        var chatBox = document.getElementById("chat-box");
        chatBox.scrollTop = chatBox.scrollHeight;
    }

    // 监听清空按钮的点击事件
    $("#clear-chat").click(function () {
        if (confirm("确定要清空聊天记录吗？")) {
            chatHistory = [];
            displayChatHistory();
        }
    });

});

function onClickCopy(event) {
    const messageText = event.target.parentNode.querySelector(".message-text").innerText;
    navigator.clipboard.writeText(messageText);
}
