using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mud_Maker.Data;

namespace Mud_Maker.Controllers
{
    public class HealthController : Controller
    {
        private ApplicationDbContext repo;
        public HealthController(ApplicationDbContext repo)
        {
            this.repo = repo;
        }
        // GET: Health
        public ActionResult Index()
        {
            return View(repo.HealthBar);
        }

        // GET: Health/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Health model)
        {
            try
            {
                repo.HealthBar.Add(new Health
                {
                    IsGained = model.IsGained,
                    Amount = model.Amount,
                });
                repo.SaveChanges();
                //return RedirectToAction("Index","model.ClientID");
                //return Index(model.ClientID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Health/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Health/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Health/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Health/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}