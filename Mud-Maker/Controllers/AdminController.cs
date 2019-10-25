using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mud_Maker.Data;
using Mud_Maker.Models;

namespace Mud_Maker.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext repo;
        public AdminController(ApplicationDbContext repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult CreateMUD()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMUD(Mud model)
        {
            try
            {
                Mud mud = new Mud { MudName=model.MudName, MudDescription=model.MudDescription };
                repo.Muds.Add(mud);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}