using Application.JobOpportunities.Commands;
using Application.JobOpportunities.Queries;
using Backoffice.Models;
using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backoffice.Controllers
{
    public class JobOpportunityController : Controller
    {
        private readonly IGetJobOpportunitiesList _query;

        public JobOpportunityController()
        {
            _query = new GetJobOpportunitiesList(new DataBaseServices());
        }
        
        public ActionResult Index()
        {
            var jobOpportunities = _query.Execute().ToList();
            return View(jobOpportunities);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JobOpportunityViewModel model)
        {
            if (ModelState.IsValid)
            {
                JobOpportunity job = new JobOpportunity
                {
                    Title = model.Title,
                    Description = model.Description,
                    Salary = model.Salary
                };

                var command = new CreateJobOpportunity(new DataBaseServices());

                var correct = command.Execute(job);

                if (correct)
                {
                    TempData["Success"] = "Job opportunity was created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "An error has occurred";

                    return View();
                }
            }
            else
            {
                return View(model);
            }
            
        }

        public ActionResult Delete(int id)
        {
            var query = new GetJobOpportunity(new DataBaseServices());

            var job = query.Execute(id);

            if (job != null)
            {
                return View(job);
            }
            else
            {
                TempData["Error"] = "Job opportunity is not valid";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteJob(int id)
        {
            var query = new DeleteJobOpportunity(new DataBaseServices());

            var result = query.Execute(id);

            if (result)
            {
                TempData["Success"] = "Job opportunity was deleted successfully";
            }
            else
            {
                TempData["Error"] = "An error has occurred";
            }

            return RedirectToAction("Index");
        }
    }
}