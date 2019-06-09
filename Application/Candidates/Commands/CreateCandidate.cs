using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;

namespace Application.Candidates.Commands
{
    public class CreateCandidate : ICreateCandidate
    {
        private readonly IDataBaseServices _database;

        public CreateCandidate(IDataBaseServices dataBase)
        {
            _database = dataBase;
        }

        public bool Execute(Candidate candidate, int idJob)
        {
            return _database.CreateCandidate(candidate, idJob);
        }
    }
}
