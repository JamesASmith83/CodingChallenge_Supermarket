namespace CodingChallenge.Interfaces
{
    public interface ICosting
    {
        char Product { get; set; }

        decimal Cost { get; set; }

        Offer Offer { get; set; }
    }
}
