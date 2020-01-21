using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task2.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        public byte[] SmallImage { get; set; }
        public byte[] LargeImage { get; set; }
    }
}