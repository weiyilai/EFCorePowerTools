﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace PostgresTester.Models
{
    public partial class EmployeeSalesbyCountryResult
    {
        public string? Country { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? OrderID { get; set; }
        public double? Subtotal { get; set; }
    }
}
