using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQs.Models
{
    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamCode { get; set; }

        public Team(int id, string name, int teamcode)
        {
            id = Id;
            name = Name;
            teamcode = TeamCode;

        }
    }
}
