using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onBoard.Models
{
    public class Hour
    {
        public int HourID { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime HourPressed { get; set; }

        public User User { get; set; }

    }
}