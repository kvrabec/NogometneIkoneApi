using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NogometneIkone.Web.Models
{
    public class NewGroupViewModel
    {
        public string GroupName { get; set; }
        public List<string> UserNames { get; set; }
    }

    public class UserGroupViewModel
    {
        public string UserName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }

    public class MessageViewModel
    {
        public int ID { get; set; }
        public string AddedBy { get; set; }
        public string message { get; set; }
        public int GroupId { get; set; }
        public string SocketId { get; set; }
    }
}
