var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

document.getElementById("connect-buttonadmin").onclick = async () => {
    event.preventDefault(); 
    var roomId = document.getElementById("room-idadmin").value;
    connection.start().then(async function() {

        console.log("connected to hub");
        await connection.invoke("AdminJoinChat", roomId);
    });
}

connection.on("AdminConnected",
    (value, client) => {
        const connectFormadmin = document.getElementById('connect-formadmin');
        const chatInterfaceadmin = document.getElementById('chat-interfaceadmin');

        connectFormadmin.style.display = 'none';
        chatInterfaceadmin.classList.remove('hidden');
        addMessageAdmin('agentadmin', `You are connected to chat, your client is :  ${client.toUpperCase()}`);
            console.log(value, client);
        });

connection.on("ErrorAdminConnection",
    (value) => {
        alert(value);
        connection.stop();
    });

connection.on("AdminMessage",
    (value) => {
        addMessageAdmin('customeradmin', value);
    });

connection.on("ReceiveMessage",
    (value) => {
        addMessageAdmin('agentadmin', value);
    });


document.getElementById("send-buttonadmin").onclick = async () => {
    await sendMessageAdmin();
};

document.getElementById("message-inputadmin").addEventListener("keypress", async (event) => {
    if (event.key === "Enter") {
        event.preventDefault(); 
        await sendMessageAdmin();
    }
});


async function sendMessageAdmin() {
    var messageAdmin = document.getElementById("message-inputadmin").value;
    if (messageAdmin.trim() !== "") { 
        await connection.invoke("SendMessage", messageAdmin);
        document.getElementById("message-inputadmin").value = ""; 
    }
}


function addMessageAdmin(sender, text) {
    const messageElementAdmin = document.createElement('div');
    messageElementAdmin.classList.add('messageadmin', sender);
    messageElementAdmin.textContent = text;
    var chatMessagesAdmin = document.getElementById("chat-messagesadmin");
    chatMessagesAdmin.appendChild(messageElementAdmin);
    chatMessagesAdmin.scrollTop = chatMessagesAdmin.scrollHeight;
}


