using AWBArchiving.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWBArchiving.Web.Controllers
{
    public class ViewsController : Controller
    {
        // GET: Views
        public ActionResult Index(int id, string search)
        {
            ViewLogic log = new ViewLogic();
            var data =  log.SearchView(id,search);
            ViewBag.Id = id;
            ViewBag.Search = search;
            return View(data.Tables[0]);
        }
        public ActionResult Search(int id, string search)
        {
            ViewLogic log = new ViewLogic();
            var data = log.SearchView(id, search);
            ViewBag.Id = id;
            ViewBag.Search = search;
            return View(data.Tables[0]);
        }

    }
}