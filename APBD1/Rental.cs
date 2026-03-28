using APBD1.Equipment;

namespace APBD1;

enum RentalState
{
    ACTIVE,
    FINISHED
}

public class Rental
{
    private static int BaseRentDurationInDays = 3;
    private RentalState State { get; set; }
    private User.User Renter { get; set; }
    private Equipment.Equipment Equipment { get; }
    private DateTime RentDate { get; set; }
    private int RentDurationInDays { get; set; }
    private DateTime? ReturnDate { get; set; }

    private DateTime ExpectedReturnDate
    {
        get => RentDate.AddDays(RentDurationInDays);
    }

    public static List<Rental> Rentals = [];

    private bool? ReturnedOnTime
    {
        get => ReturnDate.HasValue ? ReturnDate <= ExpectedReturnDate : null;
    }

    public Rental(User.User renter, Equipment.Equipment equipment, DateTime rentDate)
    {
        Renter = renter;
        RentDate = rentDate;
        RentDurationInDays = BaseRentDurationInDays;
        Equipment = equipment;

        Equipment.State = EquipmentState.Rented;
        Rentals.Add(this);
        State = RentalState.ACTIVE;
    }

    private void ExtendRental(int durationInDays)
    {
        RentDurationInDays += durationInDays;
    }

    public static List<Rental> GetUserRentals(User.User user)
    {
        return Rentals.Where(rental => rental.Renter == user).ToList();
    }

    private List<Rental> GetActiveRentals()
    {
        return Rentals
            .Where(rental => rental.State == RentalState.ACTIVE)
            .ToList();
    }

    public static void StartReturn()
    {
        Console.WriteLine("Lista aktywnych wypożyczeń");
        
        
    }

    public override string ToString()
    {
        return $"{Renter} - {RentDate}";
    }
}