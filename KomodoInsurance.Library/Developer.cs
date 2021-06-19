using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class Developer
    {
        //Plain Old C# Object (POCO)
        public long IDNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool HasAccessToPluralSight { get; set; }

        public Developer() { }

        public Developer(long iDNumber, string firstName, string lastName, bool hasAccessToPluralSight)
        {
            IDNumber = iDNumber;
            FirstName = firstName;
            LastName = lastName;
            HasAccessToPluralSight = hasAccessToPluralSight;
        }
    }
}