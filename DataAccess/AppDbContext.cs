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
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Admin> Admins{ get; set; }

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
					Name = "Movie",
					Price = 5,
                    ImgPath = "~/img/pulp_fict.jpg",
                    Note = "Description",
                    CreateDate = DateTime.Now,
                    CreateUserId = 1
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "Test",
                    Price = 15,
                    ImgPath = "~/img/pulp_fict.jpg",
                    Note = "Description",
                    CreateDate = DateTime.Now,
                    CreateUserId = 1
                });
        }
	}
}
