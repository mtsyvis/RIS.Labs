using System;

namespace Lab2.Models
{
    [Serializable]
    public class FuelRow : IEquatable<FuelRow>
    {
        public string Id { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public string FuelType { get; set; }

        public double Amount { get; set; }

        public bool Equals(FuelRow other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.Id, other.Id) && this.DateOfDelivery.Equals(other.DateOfDelivery) && string.Equals(this.FuelType, other.FuelType) && this.Amount.Equals(other.Amount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FuelRow)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.DateOfDelivery.GetHashCode();
                hashCode = (hashCode * 397) ^ (this.FuelType != null ? this.FuelType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.Amount.GetHashCode();
                return hashCode;
            }
        }
    }
}
