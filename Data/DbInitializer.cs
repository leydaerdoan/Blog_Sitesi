using Blog_Sitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog_Sitesi.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //if (_db.Roles.Any(r => r.Name == "Admin")) return;

            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Ziyaretci")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Uye")).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "said@gmail.com",
                Email = "said@gmail.com",
                Ad = "Said",
                Soyad = "Sahinbas",
                EmailConfirmed = true,
                PhoneNumber = "1112223333"
            }, "Said123*").GetAwaiter().GetResult();


            _userManager.AddToRoleAsync(_context.Users.FirstOrDefaultAsync(u => u.Email == "said@gmail.com").GetAwaiter().GetResult(), "Admin").GetAwaiter().GetResult();


            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "leydaerdoan@gmail.com",
                Email = "leydaerdoan@gmail.com",
                Ad = "İleyda",
                Soyad = "Xx_xX!!ErDoGaN!!Xx_xX",
                EmailConfirmed = true,
                PhoneNumber = "1112223333"
            }, "Ileyda123*").GetAwaiter().GetResult();


            _userManager.AddToRoleAsync(_context.Users.FirstOrDefaultAsync(u => u.Email == "leydaerdoan@gmail.com").GetAwaiter().GetResult(), "Admin").GetAwaiter().GetResult();
        }
    }
}
