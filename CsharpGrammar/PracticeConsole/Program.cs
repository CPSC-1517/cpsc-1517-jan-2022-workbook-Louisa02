// See https://aka.ms/new-console-template for more information
using PracticeConsole.Data; // gives reference to the location of classes within 
                            // the specified namespace
                            // this allows the developer to avoid having to use a fully qualified
                            // name every time a reference is made to a class in the namespace

// Fully qualified name
// PracticeConsole.Data.Employment job = CreateJob();
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();
Person Me = CreatePerson(Job, Address);
DisplayPerson(Me);

static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString($"{person.Address.ToString()}");
    foreach(var emp in person.EmploymentPositions)
    {
        DisplayString($"{emp.ToString()}");
    }
}

Employment CreateJob()
{
    Employment Job = null;
     // a reference to a variable capable of holding an instance of Employment
     // its initial value will be null
    try
    {
        Job = new Employment();
        DisplayString($"default good job {Job.ToString()}");
        // checking exceptions
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($" greedy good job {Job.ToString()}");
        // bad data: Title
        //Job = new Employment("", SupervisoryLevel.Supervisor, 5.5);
        // bad data: negative Year
        //Job = new Employment("Boss", SupervisoryLevel.Supervisor, -5);
    }
    catch (ArgumentException ex) // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return Job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress Address = new ResidentAddress();
    DisplayString($"Default Address {Address.ToString()}");
    Address = new ResidentAddress(10767, "106 ST NW", null, null, "Edmonton", "AB");
    DisplayString($"Greedy Address {Address.ToString()}");
    return Address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    List<Employment> Jobs = new List<Employment>();
    Person thePerson = null;
    try
    {
        // create a person using greedy constructot no job list
        thePerson = new Person("Louisa", "Luo", null, address);

        // create a person using greedy constructor with an empty job list
        thePerson = new Person("LouisaEmptyJob", "Luo", Jobs, address);

        // create a person using greedy constructor with a job list
        Jobs.Add(job);
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(job);
        thePerson = new Person("LouisaWithJob", "Luo", Jobs, address);

        // EXCEPTION TESTING
        // no firstName
        thePerson = new Person(null, "Luo", Jobs, address);
        // no secondName
        thePerson = new Person("LouisaWithJob", null, Jobs, address);



        // can i change the firstname using an assignment statement
        // the FirstName is a private set
        // you are NOT allowed to use a private set on the receiving side of an assignment statement
        // THIS WILL NOT COMPILE
        // thePerson.FirstName = "NewName";

        // can i use a behaviour (method) to change the contents of a private set property?
        thePerson.ChangeName("Lowand", "Behold");

        // can i add another job after the person instance was created
        thePerson.AddEmployment(new("DP IT", SupervisoryLevel.DepartmentHead, 0.8));

        // can i change the public field address directly?
        ResidentAddress oldAddress = thePerson.Address;
        oldAddress.City = "Vancouver";
        thePerson.Address = oldAddress;


    }
    catch (ArgumentException ex) // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return thePerson;
}