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
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        private Email()
        {

        }
        [Column("Address")]
        [Required(ErrorMessage = "Address is required!")]
        [EmailAddress(ErrorMessage = "Address invalid!")]
        [MaxLength(125, ErrorMessage = "The address should be a maximum of 125 characters.")]
        public string Address { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}
