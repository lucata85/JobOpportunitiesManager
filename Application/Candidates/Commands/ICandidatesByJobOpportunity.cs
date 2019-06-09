using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Candidates.Commands
{
    public interface ICandidatesByJobOpportunity
    {
        List<Candidate> Execute(int idJob);
    }
}
