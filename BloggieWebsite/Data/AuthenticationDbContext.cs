using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Data
{
    public class AuthenticationDbContext : IdentityDbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //we want to seed some role, user  Admin and supar Admin Roles

            var AdminRoleID = "fb384059-05f2-4f0c-9f17-19410344e21f";
            var SuparAdminRoleId = "2e1b2a23-b32c-4bec-baf7-ef79b1f5b4ec";
            var UserRoleID = "48a3d08f-f833-480b-8887-fc8383fa9f6b";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id= AdminRoleID,
                    ConcurrencyStamp =AdminRoleID,
                },
                new IdentityRole
                {
                    Name = "SuparAdmin",
                    NormalizedName = "SuparAdmin",
                    Id=SuparAdminRoleId,
                    ConcurrencyStamp= SuparAdminRoleId,

                },
                new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "User",
                    Id=UserRoleID,
                    ConcurrencyStamp= UserRoleID,

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var SuparAdminId = "31e4ddbd-9d44-4532-a6b4-e007459902a7";
            var SuparAdminUser = new IdentityUser
            {
                UserName = "SuparAdmin@bloggie.com",
                Email = "SuparAdmin@bloggie.com",
                NormalizedEmail = "SuparAdmin@bloggie.com".ToUpper(),
                NormalizedUserName= "SuparAdmin@bloggie.com".ToUpper(),
                Id= SuparAdminId
            };
            SuparAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(SuparAdminUser, "SuperAdmin@123");


            builder.Entity<IdentityUser>().HasData( SuparAdminUser );

            var SuperAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleID,
                    UserId = SuparAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = SuparAdminRoleId,
                    UserId = SuparAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = UserRoleID,
                    UserId = SuparAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData( SuperAdminRoles );


        }
    }
}
