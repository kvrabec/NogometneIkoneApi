using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL;
using NogometneIkone.Model;
using PusherServer;

namespace NogometneIkone.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly NIManagerDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(NIManagerDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult ChannelAuth(string channel_name, string socket_id)
        {
            int group_id;
            if (!User.Identity.IsAuthenticated)
            {
                return new ContentResult {Content = "Access forbidden", ContentType = "application/json"};
            }

            try
            {
                group_id = Int32.Parse(channel_name.Replace("private-", ""));
            }
            catch (FormatException e)
            {
                return Json(new {Content = e.Message});
            }

            var IsInChannel = _context.UserGroup
                .Where(gb => gb.GroupId == group_id
                             && gb.UserName == _userManager.GetUserName(User))
                .Count();

            if (IsInChannel > 0)
            {
                var options = new PusherOptions
                {
                    Cluster = "PUSHER_APP_CLUSTER",
                    Encrypted = true
                };
                var pusher = new Pusher(
                    "PUSHER_APP_ID",
                    "PUSHER_APP_KEY",
                    "PUSHER_APP_SECRT",
                    options
                );

                var auth = pusher.Authenticate(channel_name, socket_id).ToJson();
                return new ContentResult {Content = auth, ContentType = "application/json"};
            }

            return new ContentResult {Content = "Access forbidden", ContentType = "application/json"};
        }
    }
}