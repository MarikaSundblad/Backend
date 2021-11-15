using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MVC.Entities
{
    [Index(nameof(Email), Name = "UQ__Users__A9D10534D3FBBEC6", IsUnique = true)]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public int AddressesId { get; set; }

        [ForeignKey(nameof(AddressesId))]
        [InverseProperty(nameof(Address.Users))]
        public virtual Address Addresses { get; set; }
    }
}
