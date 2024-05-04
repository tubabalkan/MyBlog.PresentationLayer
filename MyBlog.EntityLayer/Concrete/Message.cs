using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Gonderen { get; set; }
        public string Alıcı { get; set; }
        public string Subject { get; set; }
        public string MessageDescription { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
