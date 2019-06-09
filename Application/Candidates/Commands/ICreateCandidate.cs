using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Candidates.Commands
{
    public interface ICreateCandidate
    {
        bool Execute(Candidate candidate, int idJob);
    }
}
