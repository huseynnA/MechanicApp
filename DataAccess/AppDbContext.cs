using DataAccess.Entites;
using Helper;
//using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
	

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Name = "Huseyn",
                    Surname= "Aliyev",
                    Salt = salt,
                    PasswordHash = Crypto.GenerateSHA256Hash("admin001", salt),
                    CreateDate = DateTime.Now,
                    CreateUserId = 1
                }
                ) ;

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
					Name = "Shell",
					Price = 5,
                    ImgPath = "https://media.carparts4less.co.uk/images/products/200x200/521772251.jpg",
                    Note = "Shell Helix HX7 Engine Oil - 10W-40 - 5Ltr",
                    CreateDate = DateTime.Now,
                    CreateUserId = 1
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "Triple",
                    Price = 15,
                    ImgPath = "https://media.carparts4less.co.uk/images/products/200x200/521776011.jpg?v=11.03",
                    Note = "Shell Helix HX7 Engine Oil - 10W-40 - 5Ltr",
                    CreateDate = DateTime.Now,
                    CreateUserId = 1
                });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
