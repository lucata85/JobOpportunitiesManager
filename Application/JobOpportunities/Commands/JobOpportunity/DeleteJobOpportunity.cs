using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.JobOpportunities.Commands
{
    public class DeleteJobOpportunity : IDeleteJobOpportunity
    {
        private readonly IDataBaseServices _database;

        public DeleteJobOpportunity(IDataBaseServices dataBase)
        {
            _database = dataBase;
        }

        public bool Execute(int idJob)
        {
            return _database.DeleteJobOpportunity(idJob);
        }
    }
}
