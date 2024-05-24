using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppStore.Models;

namespace WebAppStore.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { 
        
        
        }
       
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Brand> Brands { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "0d717dff-ea8e-4824-8477-a87d63d259b7";
            var userRoleId = "5a8b5e27-7197-4b22-a111-6d7f5c27ac25";
            //Seeding roles like admin,superadmin,user

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="Admin",
                    Id=adminRoleId,
                    ConcurrencyStamp=adminRoleId

                },
               
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="User",
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId

                },
            };

            //insert into builder option.
            builder.Entity<IdentityRole>().HasData(roles);



            //Seed Superadming
            var FirstAdminId = "a610a115-9e98-4a4c-a005-082cd2661ddc";

            var AdminUser = new IdentityUser
            {
                UserName = "Admin1",
                Email = "admin1@webappstore.com",
                NormalizedEmail = "admin1@webappstore.com".ToUpper(),
                NormalizedUserName = "Admin1".ToUpper(),
                Id = FirstAdminId,
            };

            //generate password for super adming
            AdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(AdminUser, "Admin1234");

            //seed now
            builder.Entity<IdentityUser>().HasData(AdminUser);

            //Now assign all roles to super admin
            var AdminUserRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId=adminRoleId,
                    UserId=FirstAdminId
                }
               
                ,new IdentityUserRole<string>
                {
                    RoleId=userRoleId,
                    UserId=FirstAdminId
                }
            };

            //seed again
            builder.Entity<IdentityUserRole<string>>().HasData(AdminUserRoles);
        }
    }
}
