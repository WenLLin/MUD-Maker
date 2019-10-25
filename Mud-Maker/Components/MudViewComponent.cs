using Microsoft.AspNetCore.Mvc;
using Mud_Maker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mud_Maker.Components
{
    public class MudViewComponent : ViewComponent
    {
        private ApplicationDbContext repo;

        public MudViewComponent(ApplicationDbContext repo)
        {
            this.repo = repo;
        }
        public IViewComponentResult Invoke()
        {
            // string controller = RouteData.Values["category"].ToString();
            ViewBag.SelectedCategory = Request.Query["Mud"];
            return View(repo.Muds
                .OrderBy(x => x));
        }
    }
}
