using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services.ChatRoomService
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IChatRoomRepository _chatRoomRepository;

        public ChatRoomService(IChatRoomRepository chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public ChatRoom GetChatRoom(Expression<Func<ChatRoom, bool>> filter)
        {
            return _chatRoomRepository.GetChatRoom(filter);
        }

        public IEnumerable<ChatRoom> GetChatRooms(Expression<Func<ChatRoom, bool>> filter)
        {
            return _chatRoomRepository.GetChatRooms(filter).ToList();
        }

        public IEnumerable<ChatRoom> GetAllChatRooms()
        {
            return _chatRoomRepository.GetAllChatRooms().ToList();
        }

        public void AddChatRoom(ChatRoom entity)
        {
            _chatRoomRepository.AddChatRoom(entity);
        }

        public void UpdateChatRoom(ChatRoom entity)
        {
            _chatRoomRepository.UpdateChatRoom(entity);
        }

        public void RemoveChatRoom(ChatRoom entity)
        {
            _chatRoomRepository.RemoveChatRoom(entity);
        }
    }
}
