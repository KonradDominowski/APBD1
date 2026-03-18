namespace APBD1.User;

public class User
{
    public static int MaxId = 0;
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(string firstName, string lastName)
    {
        Id = ++MaxId;
        FirstName = firstName;
        LastName = lastName;
    }
}