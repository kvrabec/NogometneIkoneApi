using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NogometneIkone.DAL;
using NogometneIkone.DAL.Repository;
using NogometneIkone.Model;
using NogometneIkone.Web.Models;

namespace NogometneIkone.Web.Controllers 
{
    public class HomeController : Controller
    {
        private readonly NIManagerDbContext _GroupContext;
        private QuizRepository Repository { get; }
        public HomeController(QuizRepository repository, NIManagerDbContext groupContext)
        {
            _GroupContext = groupContext;
            Repository = repository;
        }
        public IActionResult Index()
        {
            var model = Repository.GetListWithQuestions().ToList();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult API()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Chat()
        {
            //var groups = _GroupContext.UserGroup
            //   // .Where(gp => gp.UserName == _userManager.GetUserName(User))
            //    .Join(_GroupContext.Groups, ug => ug.GroupId, g => g.ID, (ug, g) =>
            //        new UserGroupViewModel
            //        {
            //            UserName = ug.UserName,
            //            GroupId = g.ID,
            //            GroupName = g.GroupName
            //        })
            //    .ToList();

            //ViewData["UserGroups"] = groups;

            //// get all users      
            //ViewData["Users"] = _userManager.Users;
            return View();
        }
    }
}
