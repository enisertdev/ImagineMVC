using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Entities
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public int UserId {get; set; }
        public User? User { get; set; }
    }
}
