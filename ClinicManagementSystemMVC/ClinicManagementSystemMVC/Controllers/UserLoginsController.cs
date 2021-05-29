using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagementSystemMVC.Models;
using ClinicManagementSystemMVC.Service;
using Microsoft.Extensions.Logging;

namespace ClinicManagementSystemMVC.Controllers
{

    public class UserLoginsController : Controller
    {

        public readonly ILogger<UserLoginsController> _logger;
        public readonly ILogin<UserLogin> _repo;
        public UserLoginsController(ILogger<UserLoginsController> logger, ILogin<UserLogin> repo)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UserLogin> userLogin = _repo.GetAll().ToList();
            return View(userLogin);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserLogin userLogin)
        {
            _repo.Add(userLogin);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            var obj = _repo.UserLogin(userLogin);
            try
            {
                if (obj != 0)
                {
                    return RedirectToAction("Success");
                }
            }
            catch (Exception e)

            {
                _logger.LogDebug(e.Message);

            }
            return RedirectToAction("Error");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}