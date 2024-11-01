using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.DataAccess.Interfaces
{
    public interface IChatRoomRepository : IGenericRepository<ChatRoom>
    {
        ChatRoom GetChatRoom(Expression<Func<ChatRoom, bool>> filter);
        IEnumerable<ChatRoom> GetChatRooms(Expression<Func<ChatRoom, bool>> filter);
        IEnumerable<ChatRoom> GetAllChatRooms();
        void AddChatRoom(ChatRoom entity);
        void UpdateChatRoom(ChatRoom entity);
        void RemoveChatRoom(ChatRoom entity);
    }
}
