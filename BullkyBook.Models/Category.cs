﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BullkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Name")]
        [Range(1, 100, ErrorMessage = "Display Order must Be between 1 to 100 only!!")]
        public string DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
