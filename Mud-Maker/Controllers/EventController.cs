using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mud_Maker.Data;
using Mud_Maker.Models;

namespace Mud_Maker.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext repo;

        public EventController(ApplicationDbContext repo)
        {
            this.repo = repo;
        }

        // GET: Event
        public ActionResult Index(int id)
        {
            var events = repo.Events.Where(x => x.MudId == id);
            var myMud = repo.Muds.Where(x => x.MudId == id).First();
            var eventViewModel = new EventViewModel { MUD=myMud, Events=events };
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //Project model = new Project { ProjectID = customer.ProjectID, CompanyName = customer.CompanyName, CompanyPhone = customer.CompanyPhone, CompanyPoc = customer.CompanyPoc };
            return View(eventViewModel);//viewModel
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            Event result = repo.Events.Where(x => x.EventId == id).FirstOrDefault();
            var events= repo.Events.Where(x => x.MudId == result.MudId).Select(s => new DirectionsViewModel{ EventId = s.EventId, EventName = s.EventName }).ToList();
            ViewBag.Directions = events;
            return View(result);
        }

        [HttpPost]
        public ActionResult Details(Event model)
        {        
                var result = repo.Events.Where(x => x.EventId == model.EventId).FirstOrDefault();
                if (result != null)
                {                    
                    try
                    {
                        result.EventName = model.EventName;
                        result.EventDescription = model.EventDescription;
                        result.EventText = model.EventText;
                        result.EventTriggered = model.EventTriggered;
                        result.DirLeft = model.DirLeft;
                        result.DirRight = model.DirRight;
                        result.DirFwd = model.DirFwd;
                        result.DirBack = model.DirBack;
                        repo.SaveChanges();
                        
                    }
                    catch
                    {
                        var events = repo.Events.Where(x => x.MudId == result.MudId).Select(s => new DirectionsViewModel { EventId = s.EventId, EventName = s.EventName }).ToList();
                        ViewBag.Directions = events;
                        return View(model);
                    }
                }
            return RedirectToAction("Index", new { id = result.MudId });
        }

        // GET: Event/Create
        public ActionResult Create(int id)
        {
            return View(new CreateEventViewModel { MUD = id, Fights=repo.Fights, Healths=repo.HealthBar, items=repo.Items });
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEventViewModel model)
        {
            try
            {
                //Project project = new Project { ProjectName = model.ProjectName, StartDate = model.StartDate, DueDate = model.DueDate, TotalTime = DateTime.Now, ClientID = model.ClientID, ProjectManagerID = 1 };
                repo.Events.Add(new Event {EventName=model.Event.EventName
                                           ,EventDescription=model.Event.EventDescription
                                           ,EventText=model.Event.EventText
                                           ,EventTriggered=model.Event.EventTriggered
                                           ,DirFwd=model.Event.DirFwd
                                           ,DirLeft = model.Event.DirLeft
                                           ,DirRight = model.Event.DirRight
                                           ,DirBack = model.Event.DirBack
                                           ,FightId = model.Event.FightId
                                           ,HealthId = model.Event.HealthId
                                           ,ItemId = model.Event.ItemId
                                           ,MudId=model.MUD
                });
                repo.SaveChanges();
                //return RedirectToAction("Index","model.ClientID");
                //return Index(model.ClientID);
                return RedirectToAction("Index", new { id = model.MUD });
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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