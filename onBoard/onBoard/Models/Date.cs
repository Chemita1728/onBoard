using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onBoard.Models
{
    public class Date
    {
        public int DateID { get; set; }
        public int UserID { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime DateButtonPressed { get; set; }
        public User User { get; set; }

    }
}