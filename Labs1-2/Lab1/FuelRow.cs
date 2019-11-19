using System;

namespace Lab1
{
    [Serializable]
    public class FuelRow
    {
        public string Id { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public string FuelType { get; set; }

        public double Amount { get; set; }
    }
}
