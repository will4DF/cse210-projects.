class PoliceMan : Person
{
    private string _weapons;
    public PoliceMan(string firstName, string lastName, int age, string weapons)
        : base(firstName, lastName, age)
    {
        _weapons = weapons;
    }
    
    public string GetPoliceManInformation()
    {
        return $"Weapons: {_weapons} -> {GetPersonInformation()}";
    }
}
