var connection = new signalR.HubConnectionBuilder().withUrl("/chat").withAutomaticReconnect().build();

connection.onreconnecting(() => {
    console.log("reconnecting..");
});

connection.onreconnected(async () => {
    console.log("reconnected to server");
    updateUIOnConnect();
    try {
        await connection.invoke("ClientConnectsChat");
        console.log("rejoined");
    } catch (error) {
        console.log("failed to rejoin", error);
    }
});

// Connect to hub when user presses connect button
document.getElementById("connect-button").onclick = async () => {
    try {
        await connection.start();
        updateUIOnConnect();
        await connection.invoke("ClientConnectsChat");
        console.log("Connected To Chat");
    } catch (error) {
        alert("Connection has failed.");
    }
};


// Functions to handle connection status and UI
function updateUIOnConnect() {
    document.getElementById('connect-button').style.display = 'none';
    document.getElementById('chat-interface').style.display = 'block';
    document.getElementById("end-chat-button").style.display = 'none';
}

function updateUIOnDisconnect() {
    document.getElementById('chat-interface').style.display = 'none';
    document.getElementById('connect-button').style.display = 'block';
}


// Message event listeners
connection.on("ReceiveConnection", (value) => console.log(value));
connection.on("ClientReconnected", (value) => {
    console.log(value);
    document.getElementById("end-chat-button").style.display = 'block';
});


connection.on("AdminConnected", (value) => {
    document.getElementById("end-chat-button").style.display = 'block';
    console.log(value);
    addMessage('agent', value);
});

connection.on("ReceiveMessage", (value) => addMessage('customer', value));
connection.on("AdminMessage", (value) => addMessage('agent', value));
connection.on("UserNotInRoom", (value) => addMessage('system', value));
connection.on("WaitingForAdmin",
    () => {
        setTimeout(() => {
                addMessage('agent', 'Waiting for an admin to join.');
            },
            1000);
    });
connection.on("ClientReconnected", () => addMessage('agent', "You have reconnected to the chat!"));

// Add message to the chat
function addMessage(sender, text) {
    const messageElement = document.createElement('div');
    messageElement.classList.add('message', sender);
    messageElement.textContent = text;

    const chatMessages = document.getElementById("chat-messages");
    chatMessages.appendChild(messageElement);
    chatMessages.scrollTop = chatMessages.scrollHeight;
}

// Send message to the server
document.getElementById("send-button").onclick = async () => await sendMessage();

document.getElementById("message-input").addEventListener("keypress", async (event) => {
    if (event.key === "Enter") {
        event.preventDefault();
        await sendMessage();
    }
});

async function sendMessage() {
    const message = document.getElementById("message-input").value;
    if (connection.state === signalR.HubConnectionState.Connected && message.trim() !== "") {
        await connection.invoke("SendMessage", message);
        document.getElementById("message-input").value = "";
    }
}

// End chat button handler
document.getElementById("end-chat-button").onclick = async () => {
    if (connection.state === signalR.HubConnectionState.Connected) {
        addMessage("You left the chat.");
        await connection.invoke("ClientDisconnectsChat");
        document.getElementById("end-chat-button").style.display = 'block';
        await connection.stop();
    }
};
