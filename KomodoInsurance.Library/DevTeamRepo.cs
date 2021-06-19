using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DevTeamRepo
    {
        //Make a field.
        private List<DevTeam> _ListOfDevTeams = new List<DevTeam>();

        //Create
        public void AddDevTeamNameToList(DevTeam devteam)
        {
            _ListOfDevTeams.Add(devteam);
        }

        public bool AddDeveloperToDevTeam(long teamID, Developer developer)
        {
            DevTeam devTeam = GetDevTeamByIDNumber(teamID);

            foreach (Developer developer1 in devTeam.TeamMembers)
            {
                if (developer1.IDNumber == developer.IDNumber)
                {
                    devTeam.TeamMembers.Add(developer1);
                    return true;
                }
            }
            return false;
        }

        // ------------------------------------------------------------------------------------------------------------------------

        //Read
        public List<DevTeam> GetDevTeamList()
        {
            return _ListOfDevTeams;
        }

        //--------------------------------------------------------------------------------------------------------------------------

        //Update
        public bool UpdateDevTeamsWithPluralSight(long teamID, Developer developer)
        {
            DevTeam devTeam = GetDevTeamByIDNumber(teamID);

            foreach (Developer developer1 in devTeam.TeamMembers)
            {
                if (developer1.IDNumber == developer.IDNumber && developer1.HasAccessToPluralSight == developer.HasAccessToPluralSight)
                {
                    devTeam.TeamMembers.Add(developer1);
                    return true;
                }
            }
            return false;
        }

        //---------------------------------------------------------------------------------------------------------------------------

        //Delete
        public bool RemoveDeveloperFromDevTeam(long teamID, Developer developer)
        {
            DevTeam devTeam = GetDevTeamByIDNumber(teamID);

            foreach (Developer developer1 in devTeam.TeamMembers)
            {
                if (developer1.IDNumber == developer.IDNumber)
                {
                    devTeam.TeamMembers.Remove(developer1);
                    return true;
                }
            }
            return false;
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        //Helper Method
        public DevTeam GetDevTeamByIDNumber(long teamID)
        {
            foreach (DevTeam devteam in _ListOfDevTeams)
            {
                if (devteam.TeamID == teamID)
                {
                    return devteam;
                }
            }
            return null;
        }
    }
}