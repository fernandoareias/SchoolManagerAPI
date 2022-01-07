using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elasticsearch.Models.VOs
{
    [Owned]
    public class Address : ValueObject
    {
        private Address()
        {

        }
      

        public Address(string city, string zipCode, string street, string state, string country)
        {
            City = city;
            ZipCode = zipCode;
            Street = street;
            State = state;
            Country = country;
        }
        [Required( ErrorMessage = "City is required")]
        [Column("City")]
        [MaxLength(50, ErrorMessage = "The city should be a maximum of 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]
        [Column("ZipCode")]
        [MaxLength(20, ErrorMessage = "The zipcode should be a maximum of 20 characters.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [Column("Street")]
        [MaxLength(90, ErrorMessage = "The street should be a maximum of 90 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Column("State")]
        [MaxLength(50, ErrorMessage = "The state should be a maximum of 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Column("Country")]
        [MaxLength(70, ErrorMessage = "The country should be a maximum of 70 characters.")]
        public string Country { get; set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
