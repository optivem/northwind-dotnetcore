﻿using System;
using System.Collections.Generic;

namespace Optivem.Northwind.Core.Domain.Entity
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeePrivilege = new HashSet<EmployeePrivilege>();
            Order = new HashSet<Order>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string BusinessPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string CountryRegion { get; set; }
        public string WebPage { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<EmployeePrivilege> EmployeePrivilege { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}