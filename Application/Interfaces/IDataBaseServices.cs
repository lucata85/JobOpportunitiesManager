using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDataBaseServices
    {
        List<JobOpportunity> JobOpportunities();
        bool CreateJobOpportunity(JobOpportunity jobOpportunity);
        bool DeleteJobOpportunity(int idJob);
        JobOpportunity GetJobOpportunity(int idJob);
        bool CreateCandidate(Candidate candidate, int idJob);
        List<Candidate> GetCandidatesByJobOpportunity(int idJob);
    }
}
