using Application.Candidates.Commands;
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
    public class RegisterController : Controller
    {
        private readonly ICreateCandidate _query;

        public RegisterController()
        {
            _query = new CreateCandidate(new DataBaseServices());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, int job)
        {
            if (ModelState.IsValid)
            {
                var candidate = new Candidate
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Address = model.Address,
                    BirthDay = model.BirthDay,
                    City = model.City,
                    Email = model.Email,
                    Genre = model.Genre,
                    IdCard = model.IdCard.ToString(),
                    Phone = model.Phone,
                    State = model.State,
                };

                var result = _query.Execute(candidate, job);

                if (result)
                {
                    TempData["Modal"] = "Thanks for your registration";
                }
                else
                {
                    TempData["Error"] = "An error has occurred";
                }
            }
            else
            {
                TempData["Error"] = "Model not valid";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}