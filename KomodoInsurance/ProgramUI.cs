using KomodoInsurance.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        // Method that runs/starts the application
        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Developers:\n" +
                    "2. Create Developer:\n" +
                    "3. Create a New Team:\n" +
                    "4. Add Developer(s) to Team:\n" +
                    "5. Delete Developer(s) from Team:\n" +
                    "6. View All Teams:\n" +
                    "7. Exit Application");
            //------------------------------------------------------------------------------------------------------
                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Search for Developer by ID Number
                        DisplayListOfDevelopers();
                        break;
                    case "2":
                        //Create Developers
                        CreateDeveloper();
                        break;
                    case "3":
                        //Create Team
                        CreateTeam();
                        break;
                    case "4":
                        //Add Developer to Team
                        AddDeveloperToTeam();
                        break;
                    case "5":
                        //Delete Developer from Team
                        DeleteDeveloperFromTeam();
                        break;
                    case "6":
                        //View Teams
                        ViewAllTeams();
                        break;
                    case "7":
                        //Exit Application
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Operation.  Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //----------------------------------------------------------------------------------------------------------
        
        //Display List of Developers
        
        private void DisplayListOfDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDeveloper = _developerRepo.GetDeveloperList();
            
            foreach(Developer developer in listOfDeveloper)
            {
                Console.WriteLine($"ID Number: {developer.IDNumber}\n" +
                    $"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"Has Access To Plural Sight: {developer.HasAccessToPluralSight}");
            }
        }
        
        //----------------------------------------------------------------------------------------------------------
        
        // Create Developer
        private void CreateDeveloper()

        {
            Library.Developer newDeveloper = new Library.Developer();

            // IDNumber
            Console.WriteLine("Enter the ID Number for the developer.");
            string iDNumberAsString = Console.ReadLine();
            newDeveloper.IDNumber = long.Parse(iDNumberAsString);

            // FirstName
            Console.WriteLine("Enter the first name of the developer.");
            newDeveloper.FirstName = Console.ReadLine();

            // LastName
            Console.WriteLine("Enter the last name of the developer.");
            newDeveloper.LastName = Console.ReadLine();

            // HasAccessToPluralSight
            Console.WriteLine("Does the developer have access to the Plural Sight online learning tool? (y/n)");
            string pluralSightString = Console.ReadLine();
             
            if(pluralSightString == "y")
            {
                newDeveloper.HasAccessToPluralSight = true;
            }
            else
            {
                newDeveloper.HasAccessToPluralSight = false; 
            }

            _developerRepo.AddDeveloperToList(newDeveloper);
        }
        //-----------------------------------------------------------------------------------------------------
        // Create Team 
        private void CreateTeam()
        {
            DevTeam devTeam = new DevTeam();
            Console.WriteLine("What ID number do you want assigned to the new team?");
            string inputAsString = Console.ReadLine();
            long input = long.Parse(inputAsString);

            devTeam.TeamID = input;

            Console.WriteLine("Enter the team name you want for the new team.");
            string input2 = Console.ReadLine();

            devTeam.TeamName = input2;

            Console.WriteLine("Enter the ID of the developer you want to add to the team.");
            string inputAsString2 = Console.ReadLine();
            long input3 = long.Parse(inputAsString2);

            devTeam.TeamMembers.Add(_developerRepo.GetDeveloperByIDNumber(input3));

            _devTeamRepo.AddDevTeamNameToList(devTeam);
        }

        //-------------------------------------------------------------------------------------------------------------
        // Add Developer to Team
        private void AddDeveloperToTeam()
        {
            Console.WriteLine("What team do you want to change?  Enter the Team ID Number.");
            string inputAsString = Console.ReadLine();
            long input = long.Parse(inputAsString);

            DevTeam devTeam = _devTeamRepo.GetDevTeamByIDNumber(input); 

            Console.WriteLine("Enter the developer's ID Number to add to the team.");
            string input2 = Console.ReadLine();
            long input3 = long.Parse(inputAsString);

            Developer developer2 = _developerRepo.GetDeveloperByIDNumber(input3);

            bool devTeam2 = _devTeamRepo.AddDeveloperToDevTeam(devTeam.TeamID, developer2);            
        }

        //-------------------------------------------------------------------------------------------------------------
        // Remove Developer from Team
        private void DeleteDeveloperFromTeam()
        {
            // Get the Team ID Number
            Console.WriteLine("What team do you want to change?");
            string inputAsString = Console.ReadLine();
            long input = long.Parse(inputAsString);

            DevTeam devteam = _devTeamRepo.GetDevTeamByIDNumber(input);

            //Get the developer to remove
            Console.WriteLine("Enter the ID number of the developer you would like to delete.");
            string inputAsString2 = Console.ReadLine();
            long input3 = long.Parse(inputAsString2);

            // Call the delete method
            Developer developer3 = _developerRepo.GetDeveloperByIDNumber(input3);

            _devTeamRepo.RemoveDeveloperFromDevTeam(input,developer3);
        }

        //-------------------------------------------------------------------------------------------------------------

        //View All Teams
        private void ViewAllTeams()
        {
            List<DevTeam> ListOfDevTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam devTeam in ListOfDevTeams)

            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"ID: {devTeam.TeamID}\n" +
                    $"Members: {devTeam.TeamMembers}");
            }
        }

        //--------------------------------------------------------------------------------------------------------------      

        //See Method
        private void SeedDeveloperList()
        {
            Developer developer = new Developer(83923, "Kim", "Smith", true);
            Developer developer1 = new Developer(44444, "Bob", "Park", false);
            Developer developer2 = new Developer(33333, "George", "Mills", true);

            _developerRepo.AddDeveloperToList(developer);
        }
    }
}