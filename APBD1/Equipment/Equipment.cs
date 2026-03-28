namespace APBD1.Equipment;

public abstract class Equipment
{
    public static int MaxId = 0;
    public int Id { get; }
    public string Name { get; set; }
    public EquipmentState State { get; set; }
    public static List<Equipment> EquipmentList = [];

    public Equipment(string name)
    {
        Id = ++MaxId;
        Name = name;
        State = EquipmentState.Available;
        EquipmentList.Add(this);
    }

    public static Equipment CreateEquipment()
    {
        Dictionary<int, string> equipmentTypes = new Dictionary<int, string>
        {
            { 1, "Kamera" },
            { 2, "Laptop" },
            { 3, "Projektor" },
        };

        foreach (var equipmentType in equipmentTypes)
            Console.WriteLine($"{equipmentType.Key}: {equipmentType.Value}");

        var option = Utilities.SelectOptionFromDictionary(equipmentTypes);

        switch (option)
        {
            case 1:
                var name = GetString("Nazwa");
                var resolution = GetString("Resolution");

                Console.WriteLine("Czy posiada statyw?");
                Console.WriteLine("1. Tak");
                Console.WriteLine("2. Nie");
                var hasTripod = Utilities.SelectOptionFromDictionary(
                    new Dictionary<int, bool>
                    {
                        { 1, true },
                        { 2, false },
                    });

                return new Camera(name, resolution, hasTripod.Equals(1));
            case 2: // TODO Create Laptop
                break;
            case 3: // TODO Create projector
                break;
        }


        return new Camera("sad", "12", true);
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

    public static void showEquipmentList()
    {
        Console.WriteLine("Lista całego wyposażenia:");
        for (int i = 0; i < EquipmentList.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {EquipmentList[i]} - {EquipmentList[i].State}");
        }
    }

    public static void showAvailableEquipmentList()
    {
        var availableEquipment = GetAvailableEquipmentDictionary();

        if (availableEquipment.Any())
        {
            Console.WriteLine("Lista dostępnego wyposażenia:");

            foreach (var eq in availableEquipment)
            {
                Console.WriteLine($"{eq.Key}: {eq.Value}");
            }
        }
        else
        {
            Console.WriteLine("Brak dostępnego sprzętu");
        }
    }

    private static Dictionary<int, Equipment> GetAvailableEquipmentDictionary()
    {
        return EquipmentList
            .Where(e => e.State == EquipmentState.Available)
            .Select((e, index) => new { e, index = index + 1 })
            .ToDictionary(x => x.index, x => x.e);
    }

    public static void StartRent()
    {
        Console.WriteLine("Wybierz sprzęt do wypożyczenia: ");
        showAvailableEquipmentList();
        Console.Write("Wybierz sprzęt: ");
        var eq = GetAvailableEquipmentDictionary()[
            Utilities.SelectOptionFromDictionary(GetAvailableEquipmentDictionary())];
        Console.WriteLine();

        User.User.showAvailableUsers();
        Console.Write("Wybierz użytkownika: ");
        var user = User.User.GetAvailableUsersDictionary()[
            Utilities.SelectOptionFromDictionary(User.User.GetAvailableUsersDictionary())];


        Console.WriteLine();
        Console.WriteLine("Wybrano:");
        Console.WriteLine($"Sprzęt: {eq}");
        Console.WriteLine($"Użytkownik: {user}");

        if (user.CanRent)
            new Rental(user, eq, DateTime.Now);
        else
            Console.WriteLine(
                $"Ten użytkownik nie może wypożyczyć więcej sprzętu, " +
                $"maksymalna liczba wypozyczeń osiągnięta ({user.MaxRentalsAvailable}).");
    }


    public override string ToString()
    {
        return Name;
    }
}