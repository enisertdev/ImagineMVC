
using System.Security.Claims;
using Imagine.Business.Services.UserService.UserService;
using Microsoft.AspNetCore.SignalR;

namespace Imagine.Hub;

public class ServerHub : Microsoft.AspNetCore.SignalR.Hub
{
    private static Dictionary<string, List<string>> _rooms = new Dictionary<string, List<string>>();

    public async Task ClientConnectsChat()
    {
        Random rnd = new Random();
        string roomId = rnd.Next(Int32.MaxValue).ToString();
        if (!_rooms.Keys.Contains(roomId))
        {
            {
                _rooms[roomId] = new List<string>();
            }
            _rooms[roomId].Add(Context.User.Identity.Name);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Caller.SendAsync("ReceiveConnection", $"You Have Sucessfully Joined to Chat, RoomId is {roomId}");
        }
    }

    public async Task ClientDisconnectsChat(string roomId)
    {
        var findRoom = _rooms.FirstOrDefault(r => r.Key == roomId);
        if (findRoom.Key != null)
        {
            _rooms.Remove(roomId);
        }
        else
        {
            return;
        }
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
    }

    public async Task AdminJoinChat(string roomId)
    {
        var roomExists = _rooms.FirstOrDefault(r => r.Key == roomId);
        if (roomExists.Key != null)
        {
            if (Context.User.IsInRole("Admin"))
            {
                _rooms[roomId].Add(Context.User.Identity.Name);
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
                var userInChat = "";
                foreach (var user in _rooms[roomId])
                {
                    userInChat = user;
                }
                await Clients.Group(roomId).SendAsync("AdminConnected", "An admin has joined to chat", userInChat);
            }
        }
        else
        {
        await Clients.Caller.SendAsync("ErrorAdminConnection", "A room with this roomId does not exist.");
        }
    }

    public async Task SendMessage(string message)
    {
        var userInRoom = false;
        var user = Context.User.Identity.Name;
        foreach (var room in _rooms)
        {
            if (room.Value.Contains(user))
            {
                userInRoom = true;
                if (Context.User.IsInRole("Admin"))
                {
                    await Clients.Group(room.Key).SendAsync("AdminMessage", message);

                }
                else
                {
                    await Clients.Group(room.Key).SendAsync("ReceiveMessage", message);
                }

                break;
            }
        }

        if (!userInRoom)
        {
            await Clients.Caller.SendAsync("UserNotInRoom", "You are not in the correct room.");
        }

    }
}