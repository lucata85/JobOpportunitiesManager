using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.JobOpportunities.Queries
{
    public class GetJobOpportunitiesList : IGetJobOpportunitiesList
    {
        private readonly IDataBaseServices _database;

        public GetJobOpportunitiesList(IDataBaseServices dataBase)
        {
            _database = dataBase;
        }

        public List<JobOpportunity> Execute()
        {
            return _database.JobOpportunities();
        }
    }
}
