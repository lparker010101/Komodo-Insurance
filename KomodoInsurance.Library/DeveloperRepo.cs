using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DeveloperRepo
    {
        //Make a field.
        private List<Developer> _listOfDevelopers = new List<Developer>();

        //------------------------------------------------------------------------------------------------------------------
        
        //Create
        public void AddDeveloperToList(Developer developer) //developer is object like "Jane".
        {
            _listOfDevelopers.Add(developer);
        }

        //------------------------------------------------------------------------------------------------------------------

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        //------------------------------------------------------------------------------------------------------------------
            
            //Update
            public bool UpdateExistingListOfDevelopersWithPluralSight(long iDNumber, Developer newDeveloper)
        {
            //Find the developer
            Developer DeveloperWithNoAccess = GetDeveloperByIDNumber(iDNumber);

            //Update the developer's access.
            if (DeveloperWithNoAccess != null)
            {
                DeveloperWithNoAccess.HasAccessToPluralSight = newDeveloper.HasAccessToPluralSight;
                DeveloperWithNoAccess.LastName = newDeveloper.LastName;
                DeveloperWithNoAccess.FirstName = newDeveloper.FirstName;

                return true;
            }
                return false;
        }

        //-------------------------------------------------------------------------------------------------------------------

        //Delete
        public bool RemoveDeveloperFromList(long iDNumber)
        {                                                               
            Developer developer = GetDeveloperByIDNumber(iDNumber);

            if (developer == null)
            {
                return false;
            }

            int InitialCountOfDevelopers = _listOfDevelopers.Count;
            {
                _listOfDevelopers.Remove(developer);

                if (InitialCountOfDevelopers > _listOfDevelopers.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        //---------------------------------------------------------------------------------------------------------------------------
        
            //Helper Method 
        public Developer GetDeveloperByIDNumber(long iDNumber)
        {
            foreach (Developer developer in _listOfDevelopers)
            {
                if (developer.IDNumber == iDNumber)
                {
                    return developer;
                }
            }
                return null;
        }
    }
}