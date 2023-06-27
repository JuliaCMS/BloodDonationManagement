namespace BloodDonationManagement.Models;

public class Contact
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? RegisteredId { get; set; }

    public string UserType { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }
}
