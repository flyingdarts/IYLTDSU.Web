using Microsoft.AspNetCore.SignalR;

namespace IYLTDSU.WebApp;

public class LobbyHub : Hub
{
    private const string GroupName = "LobbyUsers";
    private const string EventConnected = "Connected";
    private const string EventDisconnected = "Disconnected";

    public async Task LobbyUsers(string eventName, string message)
    {
        await Clients.All.SendAsync(GroupName, eventName, message);
    }

    public override async Task OnConnectedAsync()
    {
        // Add client to group
        await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);

        // Notify client connected
        await Clients.OthersInGroup(GroupName)
            .SendCoreAsync(GroupName, new object[] { EventConnected, Context.ConnectionId });

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception ex)
    {
        await base.OnDisconnectedAsync(ex);

        // Notify client disconnected
        await Clients.OthersInGroup(GroupName)
            .SendCoreAsync(GroupName, new object[] { EventDisconnected, Context.ConnectionId });
    }
}
