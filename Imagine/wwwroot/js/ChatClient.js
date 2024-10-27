var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

//connect to hub when user presses to connect button
document.getElementById("connect-button").onclick = async () => {
    connection.start().then(async function () {
        const connectButton = document.getElementById('connect-button');
        const chatInterface = document.getElementById('chat-interface');
        connectButton.style.display = 'none';
        chatInterface.style.display = 'block';
        await connection.invoke("ClientConnectsChat");
        console.log("Connected To Chat");
        setTimeout(() => {
            addMessage('agent', 'Waiting for an admin to join.');
        },
            1000);
    }).catch(() => {
        alert("connection has failed.");
    });
};



//if user joined room get log
connection.on("ReceiveConnection",
    (value) => {
        console.log(value);
    });


//if admin joined get log
connection.on("AdminConnected",
    (value) => {
        console.log(value);
        addMessage('agent', value);

    });

connection.on("ReceiveMessage",
    (value) => {
        addMessage('customer', value);
    });

connection.on("AdminMessage",
    (value) => {
        addMessage('agent', value);
    });

connection.on("UserNotInRoom",
    (value) => {
        addMessage(value);
    });

function addMessage(sender, text) {
    const messageElement = document.createElement('div');
    messageElement.classList.add('message', sender);
    messageElement.textContent = text;
    var chatMessages = document.getElementById("chat-messages");
    chatMessages.appendChild(messageElement);
    chatMessages.scrollTop = chatMessages.scrollHeight;
}

document.getElementById("send-button").onclick = async () => {
    await sendMessage();
};

document.getElementById("message-input").addEventListener("keypress", async (event) => {
    if (event.key === "Enter") {
        event.preventDefault();
        await sendMessage();
    }
});


async function sendMessage() {
    var message = document.getElementById("message-input").value;
    if (message.trim() !== "") {
        await connection.invoke("SendMessage", message);
        document.getElementById("message-input").value = "";
    }
}
