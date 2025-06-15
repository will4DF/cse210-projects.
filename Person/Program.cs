class Program
{
    public static void Main(string[] args)
    {
        Person myPerson = new Person("Bubba", "Bob", 53);

        Console.WriteLine(myPerson.GetPersonInformation());

        PoliceMan myPoliceMan = new PoliceMan("Cooper", "Silver", 34, "Pistol");
        Console.WriteLine(myPoliceMan.GetPersonInformation());              
        Console.WriteLine(myPoliceMan.GetPoliceManInformation());

        Doctor myDoctor = new Doctor("John", "Smith", 45, "Stethoscope");
        Console.WriteLine(myDoctor.GetDoctorInformation());
    }
}

