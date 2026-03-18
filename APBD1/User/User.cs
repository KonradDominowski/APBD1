using System.Reflection.Metadata;

namespace APBD1.User;

public abstract class User
{
    public static int MaxId = 0;
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxRentalsAvailable { get; }
    public static List<User> Users = [];


    protected User(string firstName, string lastName)
    {
        Id = ++MaxId;
        FirstName = firstName;
        LastName = lastName;
        Users.Add(this);
    }

    public static User CreateUser()
    {
        var firstName = GetString("Imię");
        var lastName = GetString("Nazwisko");

        while (true)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Pracownik");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                switch (number)
                {
                    case 1:
                        return new Student(firstName, lastName);
                    case 2:
                        return new Employee(firstName, lastName);
                    default:
                        continue;
                }
            }
            
            Console.WriteLine("Błędna liczba!");
        }
    }

    private static string GetString(string name)
    {
        string? input;
        do
        {
            Console.Write($"{name}: ");
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        return input!;
    }
}