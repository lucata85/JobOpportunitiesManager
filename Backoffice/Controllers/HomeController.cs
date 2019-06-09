using Application.JobOpportunities.Queries;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backoffice.Controllers
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
            var lastJobOpportunities = _query.Execute().OrderByDescending(x => x.CreatedOn).Take(3).ToList();
            return View(lastJobOpportunities);
        }

        public ActionResult List()
        {
            var JobOpportunities = _query.Execute().ToList();
            return View(JobOpportunities);
        }
    }
}