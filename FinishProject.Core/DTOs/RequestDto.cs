﻿using FinishProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishProject.Core.DTOs
{
    public class RequestDto
    {
     
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }

        public string Reason { get; set; }
        bool IsOk { get; set; }
    }
}
