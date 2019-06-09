using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.JobOpportunities.Queries
{
    public class GetJobOpportunity : IGetJobOpportunity
    {
        private readonly IDataBaseServices _database;

        public GetJobOpportunity(IDataBaseServices dataBase)
        {
            _database = dataBase;
        }

        public JobOpportunity Execute(int idJob)
        {
            return _database.GetJobOpportunity(idJob);
        }
    }
}
