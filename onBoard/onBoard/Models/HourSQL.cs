﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onBoard.Models
{
    public class HourSQL: Hour
    {
        public int HourID { get; set; }
        public User User { get; set; }
    }
}