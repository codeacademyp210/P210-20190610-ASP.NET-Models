﻿using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee{ get; set; }
        public List<Company> Companies { get; set; }

        public string FormTitle { get; set; }
        public string SubmitButton { get; set; }
        public string Action { get; set; }
    }
}