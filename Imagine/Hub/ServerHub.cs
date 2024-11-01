
using System.Security.Claims;
using Imagine.Business.Services.EmailService;
using Imagine.Business.Services.UserService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Imagine.Hub;

public class ServerHub : Microsoft.AspNetCore.SignalR.Hub
{
    private static Dictionary<string, List<string>> _rooms = new Dictionary<string, List<string>>();
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;

    public ServerHub(IEmailService emailService, IUserService userService)
    {
        _emailService = emailService;
        _userService = userService;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var username = Context.User.Identity.Name;
        var findRoom = _rooms.FirstOrDefault(r => r.Value.Contains(username));
        foreach (var user in findRoom.Value)
        {
            User adminInRoom = _userService.GetUser(u => u.Name == user && u.IsAdmin == true);
            if (adminInRoom != null)
            {
                return base.OnDisconnectedAsync(exception);
            }
        }

        _rooms[findRoom.Key].Remove(username);

        return base.OnDisconnectedAsync(exception);
    }

    public async Task ClientConnectsChat()
    {
        foreach (var room in _rooms)
        {
            if (room.Value.Contains(Context.User.Identity.Name))
            {
                ClientReconnects();
                return;
            }
        }
        Random rnd = new Random();
        string roomId = rnd.Next(Int32.MaxValue).ToString();
        if (!_rooms.Keys.Contains(roomId))
        {
            {
                _rooms[roomId] = new List<string>();
            }
            _rooms[roomId].Add(Context.User.Identity.Name);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            IEnumerable<User> admins = _userService.GetUsers(u => u.IsAdmin == true).ToList();
            foreach (var admin in admins)
            {
                _emailService.SendClientConnectedChatEmailAsync(admin.Email, "User Connected Live Chat", roomId);

            }

            await Clients.Caller.SendAsync("WaitingForAdmin");
            await Clients.Caller.SendAsync("ReceiveConnection", $"You Have Sucessfully Joined to Chat, RoomId is {roomId}");
        }
    }

    public async Task ClientDisconnectsChat()
    {
        var username = Context.User.Identity.Name;
        var findRoom = _rooms.FirstOrDefault(r => r.Value.Contains(username));
        if (findRoom.Key != null)
        {
            _rooms[findRoom.Key].Remove(username);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, findRoom.Key);
            await Clients.Group(findRoom.Key).SendAsync("ClientHasLeftChat", "The client has left the chat.");
        }
    }

    public async Task ClientReconnects()
    {
        var username = Context.User.Identity.Name;
        var findRoom = _rooms.FirstOrDefault(r => r.Value.Contains(username));
        if (!string.IsNullOrEmpty(findRoom.Key))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, findRoom.Key);
            await Clients.Caller.SendAsync("ClientReconnected");
        }
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
                    User isAdmin = _userService.GetUser(u => u.Name == user && u.IsAdmin == true);
                    if (isAdmin is null)
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