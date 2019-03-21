using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchService.Facade.IFacades;

namespace SearchService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecordFacade _recordFacade;

        public HomeController(IRecordFacade recordFacade)
        {
            _recordFacade = recordFacade;
        }

        public ActionResult Index()
        {
            var result = _recordFacade.GetAll();
            return View(result);
        }
        /*
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}