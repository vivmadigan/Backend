﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProjectResult
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public ProjectModel? Project { get; set; }
    }
}
