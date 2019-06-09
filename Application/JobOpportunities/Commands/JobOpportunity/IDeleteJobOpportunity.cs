using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.JobOpportunities.Commands
{
    interface IDeleteJobOpportunity
    {
        bool Execute(int idJob);
    }
}
