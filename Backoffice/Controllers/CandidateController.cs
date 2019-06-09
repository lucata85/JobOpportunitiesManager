using Application.Candidates.Commands;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backoffice.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidatesByJobOpportunity _query;

        public CandidateController()
        {
            _query = new CandidatesByJobOpportunity(new DataBaseServices());
        }

        public ActionResult Index(int id)
        {
            var candidates = _query.Execute(id);
            return View(candidates);
        }
    }
}