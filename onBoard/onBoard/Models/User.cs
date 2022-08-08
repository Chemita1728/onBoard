using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace onBoard.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Display(Name = "User name")]
        [Required]
        public String Name { get; set; }

        public ICollection<Date> Dates { get; set; }
    }
}
