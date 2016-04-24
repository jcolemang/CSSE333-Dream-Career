
using System;
using System.Collections.Generic;

/*
 * A set of classes meant to make populating our database 
 * easy. Wont have exactly real world data but it should
 * make it easier to find database issues.
 * 
 * @author Coleman Gibson
 */

/*
 * Really this should probably be more than one 
 * class but this is less typing and this isn't 
 * a significant part of the project so I'm 
 * choosing laziness. I would just put the contents
 * of this class outside of the class but I don't
 * think that is possible in C#
 */
namespace DreamCareer
{
    class Generator
    {
        // For random numbers
        protected Random RandomGenerator;

        // for addresses
        protected string[] PossibleRoadNames;
        protected string[] PossibleRoadEndings; // I dont know what to call this (Ave, Rd, etc)
        protected string[] PossibleCities;
        protected string[] PossibleDirections;
        protected string[] PossibleStates;
        protected int MaxRoadNumber;

        // for names
        protected string[] PossibleFirstNames;
        protected string[] PossibleLastNames;

        public Generator()
        {
            this.RandomGenerator = new Random();

            this.MaxRoadNumber = 9999;

            this.PossibleDirections = new string[] {
            "N", "S", "E", "W", ""
        };

            this.PossibleRoadNames = new string[] {
            "Hulman", "40th",
            "Hickory"
        };

            this.PossibleRoadEndings = new string[] {
            "Ave", "Rd", "St"
        };

            this.PossibleCities = new string[] {
            "Houston", "Boston",
            "Terre Haute", "Indianapolis",
            "Kalamazoo", "Seatle"
        };

            this.PossibleStates = new string[] {
            "AL", "AK", "AZ", "AR", "CA", "CO",
            "CT", "DE", "FL", "GA", "HI", "MI"
        };

            this.PossibleFirstNames = new string[] {
            "Santiago", "Mateo",
            "Juan", "Matias",
            "Daniel", "Kevin",
            "Miguel", "Liam",
            "Jackson", "Logan",
            "Lucas", "Jackson",
            "Justin", "Ethan",
            "Ryan", "Lucas",
            "Aya", "Isabel",
            "Sarah", "Marwa",
            "Mariam", "Adrienne",
            "Coleman", "James",
            "Joyce", "Fatima",
            "Aaradhana", "Esperanza",
            "Sofia", "Emma",
            "Alica", "Gabrielle"
        };

            this.PossibleLastNames = new string[] {
            "Gibson", "Yue",
            "Bharill", "Mohan",
            "Smith", "Robinson",
            "Rickert", "Williams",
            "Jones", "Johnson",
            "Miller", "Taylor",
            "Anderson", "Martin",
            "Harris", "Garcia",
            "Martinez", "Davis",
            "Baker", "Mitchell",
            "Trout", "Perez",
            "Roberts", "Turner",
            "Hall"
        };
        }

        /*
         * Just grabs a random first name from the list defined in the 
         * constructor
         */
        public string GenerateFirstName()
        {
            return this.PossibleFirstNames[
                this.RandomGenerator.Next(this.PossibleFirstNames.Length)];
        }


        /*
         * Works the name as GenerateFirstName. Grabs a random last
         * name from the list given in the constructor
         */
        public string GenerateLastName()
        {
            return this.PossibleLastNames[
                this.RandomGenerator.Next(this.PossibleLastNames.Length)];
        }


        public string GenerateAddress()
        {
            int ZipCodeLength = 5;

            string RoadNum = this.RandomGenerator.Next(this.MaxRoadNumber).ToString();
            string Direction = this.PossibleDirections[
                    this.RandomGenerator.Next(this.PossibleDirections.Length)];
            string RoadName = this.PossibleRoadNames[
                this.RandomGenerator.Next(this.PossibleRoadNames.Length)];
            string RoadEnding = this.PossibleRoadEndings[
                this.RandomGenerator.Next(this.PossibleRoadEndings.Length)];
            string City = this.PossibleCities[
                this.RandomGenerator.Next(this.PossibleCities.Length)];
            string State = this.PossibleStates[
                this.RandomGenerator.Next(this.PossibleStates.Length)];

            string Zip = "";
            int i;
            for (i = 0; i < ZipCodeLength; i++)
                Zip += this.RandomGenerator.Next(10).ToString();

            string address = RoadNum + " " + Direction + " " + RoadName + " " +
                RoadEnding + "\n" + City + " " + State + "  " + Zip;

            return address;
        }

        protected string RandomString(int MaxLength)
        {
            // python string.printable
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~ \t\n\r\x0b\x0c";
            string S = "";
            int i;
            for (i = 0; i < MaxLength; i++)
                S += chars[this.RandomGenerator.Next(chars.Length)];
            return S;
        }

    }


    class UserGenerator : Generator
    {
        private string[] PossibleEmailExtensions;
        private HashSet<string> UsedEmails;
        private HashSet<string> UsedUsernames;
        private int NumFromLast;
        private int NumFromFirst;

        public UserGenerator() : base()
        {
            this.RandomGenerator = new Random();
            this.UsedEmails = new HashSet<string>();
            this.UsedUsernames = new HashSet<string>();

            this.NumFromFirst = 2;
            this.NumFromLast = 5;



            this.PossibleEmailExtensions = new string[] {
            "@rose-hulman.edu",
            "@gmail.com"
        };


        }

        // TODO test this
        public void GenerateUsers(int numUsers)
        {
            string fname;
            string lname;
            string username;
            string password;
            string email;

            int i;
            for (i = 0; i < numUsers; i++)
            {
                fname = this.GenerateFirstName();
                lname = this.GenerateLastName();
                username = this.GenerateUsername(fname, lname);
                email = this.GenerateEmail(fname, lname);
                password = this.RandomString(10);

                Console.WriteLine(username, email, password);

                Database.CreateUser(username, password, email);
            }
        }


        private string GenerateUsername(string FirstName, string LastName)
        {
            string baseString = FirstName + LastName;
            string username = baseString;
            int counter = 0;

            while (this.UsedUsernames.Contains(username))
            {
                username = baseString + counter.ToString();
                counter++;
            }

            // Note that it is not certain that this username 
            // is actually used in the database.
            this.UsedUsernames.Add(username);
            return username;
        }


        /*
         * Takes a number of letters from the first and last names
         * to generate a potential email. If the generated email
         * is already in use it starts adding numbers to it.
         */
        private string GenerateEmail(string FirstName, string LastName)
        {
            string BaseString = "";

            if (LastName.Length < this.NumFromLast)
                BaseString = BaseString + LastName.Substring(0, LastName.Length);
            else
                BaseString = BaseString + LastName.Substring(0, this.NumFromLast);

            if (FirstName.Length < this.NumFromFirst)
                BaseString = BaseString + FirstName.Substring(0, FirstName.Length);
            else
                BaseString = BaseString + FirstName.Substring(0, this.NumFromFirst);

            string EmailExtension = this.PossibleEmailExtensions[
                    this.RandomGenerator.Next(this.PossibleEmailExtensions.Length)
                ];

            string email = BaseString + EmailExtension;
            int counter = 0;
            while (this.UsedEmails.Contains(email))
            {
                email = BaseString + counter.ToString() + EmailExtension;
                counter++;
            }

            // Note that it is not certain that this email 
            // is actually used in the database.
            this.UsedEmails.Add(email);
            return email;
        }



    }


    class CompanyGenerator : Generator
    {
        private int MaxCompanySize;
        private string[] PossibleNamesStart;
        private string[] PossibleNamesMiddle;
        private string[] PossibleNamesEnd;
        private int MaxDescriptionLength;


        public CompanyGenerator() : base()
        {

            this.MaxCompanySize = 100000;

            this.PossibleNamesStart = new string[] {
            "", "The"
        };

            this.PossibleNamesMiddle = new string[] {
            "Technology", "Steel", "Car",
            "Bicycle", "Dog", "Toy", "Baby",
            "People"
        };

            this.PossibleNamesEnd = new string[] {
            "People", "Builders", "Creators"
        };

            this.MaxDescriptionLength = 500;
        }


        private int GenerateSize()
        {
            return this.RandomGenerator.Next(this.MaxCompanySize);
        }


        private string GenerateName()
        {
            string Name = "";
            Name += this.PossibleNamesStart[
                this.RandomGenerator.Next(this.PossibleNamesStart.Length)];
            Name += " ";
            Name += this.PossibleNamesMiddle[
                this.RandomGenerator.Next(this.PossibleNamesMiddle.Length)];
            Name += " ";
            Name += this.PossibleNamesEnd[
                this.RandomGenerator.Next(this.PossibleNamesEnd.Length)];
            return Name;
        }


        private string GenerateDescription()
        {
            return this.RandomString(this.MaxDescriptionLength);
        }


        public void GenerateCompanies(int NumCompanies)
        {
            string address;
            int size;
            string name;
            string description;

            int i;
            for (i = 0; i < NumCompanies; i++)
            {
                address = this.GenerateAddress();
                size = this.GenerateSize();
                name = this.GenerateName();
                description = this.GenerateDescription();

                Database.CreateCompany(address, size, name, description);
            }
        }

    }


    class PositionGenerator : Generator
    {
        private string[] PossibleTypes;
        private int MaxSalary;
        private int MinSalary;
        private string[] PossibleTags;
        private int MaxNumTags;
        private int MaxDescriptionLength;


        public PositionGenerator() : base()
        {
            this.MaxDescriptionLength = 500;

            this.PossibleTypes = new string[] {
            "Internship", "Full Time",
            "Part Time"
        };

            this.MaxSalary = 2000000;
            this.MinSalary = 10000;

            this.PossibleTags = new string[] {
            "SQL", "C#", "Web", "Design",
            "Python", "Ruby", "Systems",
            "Security"
        };
        }


        private string GenerateType()
        {
            return this.PossibleTypes[
                this.RandomGenerator.Next(this.PossibleTypes.Length)];
        }


        private string GenerateLocation()
        {
            return this.PossibleCities[
                this.RandomGenerator.Next(this.PossibleCities.Length)];
        }


        private int GenerateSalary()
        {
            return this.RandomGenerator.Next(this.MinSalary, this.MaxSalary);
        }


        private string[] GenerateTags()
        {
            int NumTags = this.RandomGenerator.Next(this.MaxNumTags);
            string[] Tags = new string[NumTags];
            int i;

            for (i = 0; i < NumTags; i++)
            {
                Tags[i] = this.PossibleTags[
                    this.RandomGenerator.Next(this.PossibleTags.Length)];
            }

            return Tags;
        }


        private string GenerateDecription()
        {
            return this.RandomString(this.MaxDescriptionLength);
        }
    }


    class ProfileGenerator : Generator
    {
        private string[] PossibleGenders;
        private string[] PossibleMajors;
        private int MaxExperienceLength;
        HashSet<int> UsedUserIDs;

        public ProfileGenerator() : base()
        {
            this.UsedUserIDs = new HashSet<int>();
            this.MaxExperienceLength = 500;

            this.PossibleGenders = new string[] {
            "M", "F", "Other" 
            //prefer not to respond will probably be 
            // represented as a null value
        };


            this.PossibleMajors = new string[] {
            "Computer Science",
            "Software Engineering",
            "Mechanical Engineering",
            "Mathematics"
        };
        }


        private string GenerateGender()
        {
            return this.PossibleGenders[
                this.RandomGenerator.Next(this.PossibleGenders.Length)];
        }


        private string GenerateMajor()
        {
            return this.PossibleMajors[
                this.RandomGenerator.Next(this.PossibleMajors.Length)];
        }


        private string GenerateExperience()
        {
            return this.RandomString(this.MaxExperienceLength);
        }

        public void GenerateProfiles(int NumProfiles)
        {
            string name;
            string gender;
            string major;
            string address;
            string experience;
            int userid;

            int i;
            for (i = 0; i < NumProfiles; i++)
            {
                name = this.GenerateFirstName() + " " + 
                    this.GenerateLastName();
                gender = this.GenerateGender();
                major = this.GenerateMajor();
                address = this.GenerateAddress();
                experience = this.GenerateExperience();
                userid = Database.GetRandomUserID();

                int counter = 0;
                while (this.UsedUserIDs.Contains(userid))
                {
                    userid = Database.GetRandomUserID();
                    counter++;
                    if (counter > 20)
                        return;
                }

                this.UsedUserIDs.Add(userid);

                Database.CreateUserProfile(name, gender, major,
                    address, experience, userid);
            }
        }
    }
}