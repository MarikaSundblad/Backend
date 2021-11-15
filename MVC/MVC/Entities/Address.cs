using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MVC.Entities
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine { get; set; }
        public short? HouseNr { get; set; }
        [Required]
        [StringLength(5)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [InverseProperty(nameof(User.Addresses))]
        public virtual ICollection<User> Users { get; set; }
    }
}
