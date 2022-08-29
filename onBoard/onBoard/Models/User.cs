using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace onBoard.Models
{
    public class User
    {

        [Display(Name = "User name")]
        [Key]
        [Required]
        public String Name { get; set; }
        public virtual ICollection<Hour> Hours { get; set; }

    }
}
