using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;

namespace Shopbridge_base.Data
{
    public class Shopbridge_Context : DbContext
    {
        public Shopbridge_Context (DbContextOptions<Shopbridge_Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<UsersModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            UsersModel user = new UsersModel()
            {
                id =1,
                UserName = "Gyan",
                Address = "New Raipur Chhattisgarh",
                EmailId = "gyan@gmail.com",
                Mobile = "9691655520",
                OfficeFlag = "admin",
                Pwd = "gyan@123"
            };           

            builder.Entity<UsersModel>().HasData(user);
        }

        
    }
}
