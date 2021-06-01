using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Service;

namespace ClinicManagementMVC.Controllers
{
    public class UserloginsController : Controller
    {
        private IRepo<UserLogin> _repo;
        public UserloginsController(IRepo<UserLogin> repo)
        {
            _repo = repo;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin reg)
        {
            UserLogin log = new UserLogin();
            if (ModelState.IsValid)
            {
                var Details = (from userlist in db.LoginTable
                               where userlist.Username == reg.Username && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.Username
                               }).ToList();
                if (Details.FirstOrDefault() != null)
                {
                    log.Username = Details.FirstOrDefault().Username;
                    return RedirectToAction("Welcome", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(reg);
        }
    }
}