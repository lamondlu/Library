using BookingLibrary.UI.DTOs;
using BookingLibrary.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
    public class LeaseController : Controller
    {
        private string _leaseApiBaseUrl => ConfigurationManager.AppSettings["leaseApiUrl"];

        public LeaseController()
        {

        }

        public ActionResult UnreturnedBooks()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<UnreturnedBookViewModel>>($"{_leaseApiBaseUrl}/api/unreturned_books");
            return View(data);
        }
    }
}