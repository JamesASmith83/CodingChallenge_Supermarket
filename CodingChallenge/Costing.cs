using CodingChallenge.Interfaces;

namespace CodingChallenge
{
    public class Costing : ICosting
    {
        public char Product { get; set; }

        public decimal Cost { get; set; }

        public Offer Offer { get; set; }
    }

    public class Offer
    {
        public int Quantity { get; set; }

        public decimal OfferCost { get; set; }
    }
}
