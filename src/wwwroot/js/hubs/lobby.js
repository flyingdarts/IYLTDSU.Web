"use strict";
// Write your Javascript code.

const connection = new signalR.HubConnectionBuilder().withUrl("/hubs/lobby").build();

connection.on("LobbyUsers",
    (eventName, message) => {
        console.log(`${eventName}: ${message}`);
        if (eventName === "Connected") {
            AddListItem(`<span style='color: green;'>${message}</span>`);
        } else if (eventName === "Disconnected") {
            AddListItem(`<span style='color: red;'>${message}</span>`);
        } else {
            AddListItem(`<span>I assume this wont happen;</span>`);
        }
    });

async function start() {
    try {
        await connection.start();
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

// Start the connection.
start();