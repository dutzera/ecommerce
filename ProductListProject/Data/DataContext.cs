using Microsoft.EntityFrameworkCore;
using ProductListProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductListProject.Data
{ 
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
    :   base(options)
        { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderedModel> Ordered_list { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProductsBD;Data Source=DESKTOP-LKNVMQT");
        }
    }
}
