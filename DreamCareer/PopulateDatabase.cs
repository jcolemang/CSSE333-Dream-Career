
using System;
using System.Collections.Generic;


class Generator
{
    protected Random RandomGenerator;

    public Generator()
    {
        this.RandomGenerator = new Random();
    }

}


class UserGenerator : Generator
{
    private string[] PossibleFirstNames;
    private string[] PossibleLastNames;
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

        string[] PossibleFirstNames = new string[] {
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

        this.PossibleEmailExtensions = new string[] {
            "@rose-hulman.edu",
            "@gmail.com"
        };


    }

    public void PopulateUser(int numUsers)
    {
        // Note that ProfileID should probably be 
        // autoincremented by the database itself

        int i;
        for (i = 0; i < numUsers; i++)
        {
            // insert into user
        }
    }


    public string GenerateUsername(string FirstName, string LastName)
    {
        string baseString = FirstName + LastName;
        string username = baseString;
        int counter = 0;

        while (!(this.UsedUsernames.Contains(username)))
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
    public string GenerateEmail(string FirstName, string LastName)
    {
        string BaseString = "";

        if (LastName.Length < this.NumFromLast)
            BaseString = BaseString + LastName.Substring(0, LastName.Length - 1);
        else
            BaseString = BaseString + LastName.Substring(0, this.NumFromLast);

        if (FirstName.Length < this.NumFromFirst)
            BaseString = BaseString + FirstName.Substring(0, FirstName.Length - 1);
        else
            BaseString = BaseString + FirstName.Substring(0, this.NumFromFirst);

        string EmailExtension = this.PossibleEmailExtensions[
                this.RandomGenerator.Next(this.PossibleEmailExtensions.Length - 1)
            ];

        string email = BaseString + EmailExtension;
        int counter = 0;
        while (!this.UsedEmails.Contains(email))
        {
            email = BaseString + counter.ToString() + EmailExtension;
            counter++;
        }

        // Note that it is not certain that this email 
        // is actually used in the database.
        this.UsedEmails.Add(email);
        return email;
    }


    /*
     * Just grabs a random first name from the list defined in the 
     * constructor
     */
    public string GenerateFirstName()
    {
        return this.PossibleFirstNames[
            this.RandomGenerator.Next(this.PossibleFirstNames.Length-1)];
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
    
}


class CompanyGenerator : Generator
{

    private string PossibleAddresses;
    private int MaxSize;
    private string[] PossibleNames;



    public CompanyGenerator() : base()
    {

    }


}