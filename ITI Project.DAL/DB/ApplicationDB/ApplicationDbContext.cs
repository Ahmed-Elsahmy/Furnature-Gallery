﻿using ITI_Project.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.DAL.DB.ApplicationDB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Follow> follows { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }



    }
}
