using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.JobOpportunities.Queries
{
    public interface IGetJobOpportunity
    {
        JobOpportunity Execute(int idJob);
    }
}
