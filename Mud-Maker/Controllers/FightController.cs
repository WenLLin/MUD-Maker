using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mud_Maker.Data;

namespace Mud_Maker.Controllers
{
    public class FightController : Controller
    {
        private ApplicationDbContext repo;
        public FightController(ApplicationDbContext repo)
        {
            this.repo = repo;
        }
        // GET: Fight
        public ActionResult Index()
        {
            return View(repo.Fights);
        }

        // GET: Fight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fight model)
        {
            try
            {
                repo.Fights.Add(new Fight
                {
                    Health = model.Health, Name=model.Name, AttackPower=model.AttackPower
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

        // GET: Fight/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fight/Edit/5
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

        // GET: Fight/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fight/Delete/5
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