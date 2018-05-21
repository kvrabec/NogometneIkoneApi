using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL;
using NogometneIkone.Model;
using NogometneIkone.Model.Game.Room;
using NogometneIkone.Web.Models;
using PusherServer;

namespace NogometneIkone.Web.Controllers.API.Chat
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private readonly NIManagerDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public MessageController(NIManagerDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{group_id}")]
        public IEnumerable<Message> GetById(int group_id)
        {
            return _context.Message.Where(gb => gb.GroupId == group_id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageViewModel message)
        {
            Message new_message = new Message { AddedBy = _userManager.GetUserName(User), message = message.message, GroupId = message.GroupId };

            _context.Message.Add(new_message);
            _context.SaveChanges();

            var options = new PusherOptions
            {
                Cluster = "PUSHER_APP_CLUSTER",
                Encrypted = true
            };
            var pusher = new Pusher(
                "PUSHER_APP_ID",
                "PUSHER_APP_KEY",
                "PUSHER_APP_SECRET",
                options
            );
            var result = await pusher.TriggerAsync(
                "private-" + message.GroupId,
                "new_message",
                new {new_message},
                new TriggerOptions() {SocketId = message.SocketId});

            return new ObjectResult(new { status = "success", data = new_message });
        }
    }
}