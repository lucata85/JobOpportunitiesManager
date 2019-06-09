using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.Candidates.Commands
{
    public class CandidatesByJobOpportunity : ICandidatesByJobOpportunity
    {
        private readonly IDataBaseServices _database;

        public CandidatesByJobOpportunity(IDataBaseServices dataBase)
        {
            _database = dataBase;
        }

        public List<Candidate> Execute(int idJob)
        {
            return _database.GetCandidatesByJobOpportunity(idJob);
        }
    }
}
