using Cherry.Domain.Common;
using System;
using System.Collections.Generic;

namespace Cherry.Domain.FoodAggregate
{
    public class Address : ValueObject
    {
        private Address() { }

        public Address(City city, string street, string alley, byte no)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentNullException("street");

            if (street.Length > 16)
                throw new ArgumentOutOfRangeException("street","length should be less than 17 chars");

            if (string.IsNullOrWhiteSpace(alley))
                throw new ArgumentNullException("alley");

            if(alley.Length > 16)
                throw new ArgumentOutOfRangeException("alley","length should be less than 17 chars");

            if (!Enum.IsDefined(typeof(City), city))
                throw new ArgumentException("city value is wrong");

            City = city;
            Street = street;
            Alley = alley;
            No = no;
        }

        public City City { get; }
        public string Street { get; }
        public string Alley { get; }
        public byte No { get; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return Street;
            yield return Alley;
            yield return No;
        }

        public static bool operator ==(Address address1, Address address2)
        {
            return address1.City == address1.City && address1.Street == address2.Street
                && address1.Alley == address2.Alley
                && address1.No == address2.No;
        }

        public static bool operator !=(Address address1, Address address2)
        {
            return !(address1 == address2);
        }
    }
}