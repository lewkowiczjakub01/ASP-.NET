using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Address
    {
        private string street;
        private string streetNumber;
        private string apartmentNumber;
        private string city;

        public Address() { }
        public Address(string street, string streetNumber, string apartmentNumber, string city)
        {
            this.street = street;
            this.streetNumber = streetNumber;
            this.apartmentNumber = apartmentNumber;
            this.city = city;
        }

        public string getStreet() { return street; }
        public void setStreet(string street) { this.street = street; }
        public string getStreetNumber() { return streetNumber; }
        public void setStreetNumber(string streetNumber) { this.streetNumber = streetNumber; }
        public string getApartmentNumber() { return apartmentNumber; }
        public void setApartmentNumber(string apartmentNumber) { this.apartmentNumber = apartmentNumber; }
        public string getCity() { return city; }
        public void setCity(string city) { this.city = city; }
        public override string ToString() {
            return "\n\tStreet: " + street + "\n\tStreet Number: " + streetNumber + "\n\tApartment Number: " + apartmentNumber + "\n\tCity: " + city;
        }
    }
}
