using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;
using Imagine.Database;
using Microsoft.EntityFrameworkCore;

namespace Imagine.DataAccess.Repositories
{
    public class ChatRoomRepository : GenericRepository<ChatRoom>, IChatRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public ChatRoom GetChatRoom(Expression<Func<ChatRoom, bool>> filter)
        {
            return _context.ChatRooms.Include(u => u.User).FirstOrDefault(filter);
            _context.SaveChanges();
        }

        public IEnumerable<ChatRoom> GetChatRooms(Expression<Func<ChatRoom, bool>> filter)
        {
            return _context.ChatRooms.Include(u => u.User).Where(filter).ToList();
            _context.SaveChanges();
        }

        public IEnumerable<ChatRoom> GetAllChatRooms()
        {
            return _context.ChatRooms.Include(u => u.User).ToList();
            _context.SaveChanges();
        }

        public void AddChatRoom(ChatRoom entity)
        {
            _context.ChatRooms.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateChatRoom(ChatRoom entity)
        {
            _context.ChatRooms.Update(entity);
            _context.SaveChanges();
        }

        public void RemoveChatRoom(ChatRoom entity)
        {
            _context.ChatRooms.Remove(entity);
            _context.SaveChanges();
        }
    }
}
