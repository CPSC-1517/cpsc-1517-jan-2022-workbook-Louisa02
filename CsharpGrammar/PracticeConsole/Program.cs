// See https://aka.ms/new-console-template for more information
using PracticeConsole.Data; // gives reference to the location of classes within 
                            // the specified namespace
                            // this allows the developer to avoid having to use a fully qualified
                            // name every time a reference is made to a class in the namespace

// Fully qualified name
// PracticeConsole.Data.Employment job = CreateJob();
Employment job = CreateJob();
ResidentAddress Address = CreateAddress();


static void DisplayString(string text)
{
    Console.WriteLine(text);
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