﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onBoard.Models
{
    public class Hours
    {
        public List<Hour> HourList { get; set; }

    }
}