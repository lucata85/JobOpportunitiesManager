using Application.JobOpportunities.Queries;
using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetJobOpportunitiesList _query;

        public HomeController()
        {
            _query = new GetJobOpportunitiesList(new DataBaseServices());
        }

        public ActionResult Index()
        {
            ViewBag.Genres = Genres();

            List<JobOpportunity> jobs = _query.Execute();
            return View(jobs);
        }

        private List<SelectListItem> Genres()
        {
            var genres = new List<SelectListItem>()
            {
                new SelectListItem{ Value="", Text = "Choose" },
                new SelectListItem{ Value = "F", Text = "Female"},
                new SelectListItem{ Value = "M", Text = "Male"},
            };

            return genres;
        }
    }
}