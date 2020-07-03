using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BiSanat.DAL.Entities;

namespace BiSanat.DAL.Repositories
{
    public class BiContext : DbContext
    {
        public BiContext(DbContextOptions<BiContext> options) : base(options)
        {
        }

        public DbSet<CategoriesProduct> CategoriesProducts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
