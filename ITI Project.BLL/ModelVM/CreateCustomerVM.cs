﻿using ITI_Project.DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.BLL.ModelVM
{
    public class CreateCustomerVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int? Age { get; set; }

        public string? Phone_Number { get; set; }
        public string? Location { get; set; }

        public List<Order>? Orders { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<Product>? FavProduct { get; set; }
        public List<Invoice>? Invoices { get; set; }
    }
}
