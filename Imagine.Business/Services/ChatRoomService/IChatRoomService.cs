using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services.ChatRoomService
{
    public interface IChatRoomService
    {
        ChatRoom GetChatRoom(Expression<Func<ChatRoom, bool>> filter);
        IEnumerable<ChatRoom> GetChatRooms(Expression<Func<ChatRoom, bool>> filter);
        IEnumerable<ChatRoom> GetAllChatRooms();
        void AddChatRoom(ChatRoom entity);
        void UpdateChatRoom(ChatRoom entity);
        void RemoveChatRoom(ChatRoom entity);
    }
}
