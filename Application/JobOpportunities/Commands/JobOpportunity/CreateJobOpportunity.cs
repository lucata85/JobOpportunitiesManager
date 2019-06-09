using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.JobOpportunities.Commands
{
    public class CreateJobOpportunity : ICreateJobOpportunity
    {
        private readonly IDataBaseServices _database;

        public CreateJobOpportunity(IDataBaseServices dataBase)
        {
            _database = dataBase;
        }

        public bool Execute(JobOpportunity jobOpportunity)
        {
            return _database.CreateJobOpportunity(jobOpportunity);
        }
    }
}
