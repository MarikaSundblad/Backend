using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MVC.Entities
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column("ImageURL")]
        public string ImageUrl { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
