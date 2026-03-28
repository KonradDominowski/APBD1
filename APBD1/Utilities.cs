namespace APBD1;

public static class Utilities
{
    public static int SelectOptionFromDictionary<T>(Dictionary<int, T> dict)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out var number) && dict.ContainsKey(number))
            {
                return number;
            }

            Console.WriteLine("Błędna liczba!");
        }
    }
}