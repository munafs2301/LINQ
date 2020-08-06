using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQs.Models
{
    class EmployeeTeam
    {
        public int EmployeeId { get; set; }
        public int TeamId { get; set; }

        public EmployeeTeam(int id, int Tid)
        {
            EmployeeId = id;
            TeamId = Tid;
        }
    }
}
