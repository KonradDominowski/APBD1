namespace APBD1.User;

public abstract class User
{
    public static int MaxId;
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxRentalsAvailable { get; }
    public static List<User> Users = [];

    public bool CanRent => Rental.GetUserRentals(this).Count < MaxRentalsAvailable;


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

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public static void showAvailableUsers()
    {
        Console.WriteLine("Lista dostępnych użytkowników:");
        foreach (var user in GetAvailableUsersDictionary())
            Console.WriteLine($"{user.Key}: {user.Value}");
    }

    public static Dictionary<int, User> GetAvailableUsersDictionary()
    {
        return Users
            .Where(user => user.CanRent)
            .Select((user, index) => new { user, index = index + 1 })
            .ToDictionary(x => x.index, x => x.user);
    }
}