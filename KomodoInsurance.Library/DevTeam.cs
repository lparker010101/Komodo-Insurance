using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public long TeamID { get; set; }
        public List<Developer> TeamMembers { get; set; } = new List<Developer>();

        public DevTeam() { }

        public DevTeam(string teamName, long teamID, List<Developer> teamMembers)
        {
            TeamName = teamName;
            TeamID = teamID;
            TeamMembers = teamMembers;
        }
    }
}