using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
    public class BookRepositoyController : Controller
    {
        // GET: BookRepositoy
        public ActionResult List()
        {
            return View();
        }
    }
}