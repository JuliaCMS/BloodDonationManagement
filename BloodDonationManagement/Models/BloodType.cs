namespace BloodDonationManagement.Models
{
    public enum ABOType
    {
        A, B, AB, O
    }

    public enum RhType
    {
        Positive = '+', Negative = '-'
    }

    public enum BloodComponentType
    {
        RBC, Plasma, Platelets, Cryoprecipitate
    }

    public class BloodType
    {
        public int Id { get; set; }

        public ABOType ABO { get; set; }

        public RhType Rh { get; set; }

        public BloodComponentType Component { get; set; }
    }
}
