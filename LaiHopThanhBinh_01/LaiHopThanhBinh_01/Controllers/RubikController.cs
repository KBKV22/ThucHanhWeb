using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaiHopThanhBinh_01.Controllers
{
    public class RubikController : Controller
    {
        // GET: Rubik
        Models.RubikStore store = new Models.RubikStore();
        public ActionResult Index()
        {
            var all_rubik = from s in store.Rubiks select s;
            return View(all_rubik);
        }
    }
}