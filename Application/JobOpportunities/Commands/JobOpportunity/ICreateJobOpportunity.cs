using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.JobOpportunities.Commands
{
    interface ICreateJobOpportunity
    {
        bool Execute(JobOpportunity jobOpportunity);
    }
}
