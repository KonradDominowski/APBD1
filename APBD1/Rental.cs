namespace APBD1;

public class Rental
{
    private User.User Renter { get; set; }
    private List<Equipment.Equipment> Equipment { get; }
    private DateTime RentDate { get; set; }
    private int RentDurationInDays { get; set; }
    private DateTime? ReturnDate { get; set; }

    private DateTime ExpectedReturnDate
    {
        get => RentDate.AddDays(RentDurationInDays);
    }

    private bool? ReturnedOnTime
    {
        get => ReturnDate.HasValue ? ReturnDate <= ExpectedReturnDate : null;
    }

    public Rental(User.User renter, DateTime rentDate, int rentDurationInDays)
    {
        this.Renter = renter;
        this.RentDate = rentDate;
        this.RentDurationInDays = rentDurationInDays;
        this.Equipment = [];
    }
}