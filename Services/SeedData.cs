using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Models;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Services
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var context = services.GetRequiredService<ApplicationDbContext>();

            // Seed companies first
            await SeedCompanies(context);

            // Then seed admin user and roles
            await SeedRolesAndAdmin(userManager, roleManager);
        }

        private static async Task SeedCompanies(ApplicationDbContext context)
        {
            if (!await context.InternComs.AnyAsync())
            {
                await context.InternComs.AddRangeAsync(
                    new InternCom
                    {
                        Name = "Tech Innovators Inc.",
                        Industry = "Information Technology",
                        Description = "Leading provider of AI solutions",
                        Website = "https://techinnovators.example",
                        Image = "https://logo.clearbit.com/techinnovators.com",
                        Address = "No(356) Alice Rode",
                        City = "San Francisco",
                        Country = "USA",
                        OffersInternships = true,
                        Email = "internships@techinnovators.example",
                        PhoneNumber = "09-796727093"
                    },
                    new InternCom
                    {
                        Name = "Green Energy Solutions",
                        Industry = "Renewable Energy",
                        Description = "Sustainable energy pioneers",
                        Website = "https://greenenergy.example",
                        Image = "https://logo.clearbit.com/greenenergy.com",
                        Address = "No(356) Alice Rode",
                        City = "Berlin",
                        Country = "Germany",
                        OffersInternships = true,
                        Email = "careers@greenenergy.example",
                        PhoneNumber = "09-796727093"
                    },
                    // Add more sample companies...
                    new InternCom
                    {
                        Name = "Global Finance Group",
                        Industry = "Financial Services",
                        Description = "International banking services",
                        Website = "https://globalfinance.example",
                        Image = "https://logo.clearbit.com/globalfinance.com",
                        Address = "No(356) Alice Rode",
                        City = "New York",
                        Country = "USA",
                        OffersInternships = false,
                        Email = "careers@greenenergy.example",
                        PhoneNumber = "09-796727093"
                    },

                    // Add these inside context.InternComs.AddRange(...)
                    new InternCom
                    {
                      Name = "Consult‑Myanmar Co Ltd",
                      Industry = "Business Consultancy",
                         Description = "Singapore‑owned advisory firm offering 4‑month graduate internships in Yangon.",
    Website = "http://consult-myanmar.com",
    Image = "https://logo.clearbit.com/consult-myanmar.com",
    Address = "47 Kaingdan St, 1st Floor, Lanmadaw Township",
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = "info@consult-myanmar.com",
    PhoneNumber = null  // not publicly listed
},

new InternCom
{
    Name = "KEISUUGIKEN Myanmar",
    Industry = "Information Technology",
    Description = "Japanese‑partnered IT firm running paid internships with UIT/UCSY students.",
    Website = "https://www.keisuu.co.jp/mminternships/",
    Image = "https://logo.clearbit.com/keisuu.co.jp",
    Address = "UIT Campus / Keisuugiken Myanmar Office",
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = null,
    PhoneNumber = null
},

new InternCom
{
    Name = "MPRL E&P",
    Industry = "Oil & Gas / Energy",
    Description = "Energy firm providing technical internships for engineering students (e.g. petroleum).",
    Website = "https://mprlexp.com",
    Image = "https://logo.clearbit.com/mprlexp.com",
    Address = "Yangon Office",
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = null,
    PhoneNumber = null
},

new InternCom
{
    Name = "nexlabs",
    Industry = "IT / Software Development",
    Description = "Yangon‑based tech studio offering hands‑on dev internships (e.g. Android, web apps).",
    Website = "https://www.nexlabs.co",
    Image = "https://logo.clearbit.com/nexlabs.co",
    Address = "MICT Park, Yangon",
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = null,
    PhoneNumber = null
},

new InternCom
{
    Name = "TNY Legal Co., Ltd",
    Industry = "Legal Services",
    Description = "Myanmar‑Japan legal firm accepting short‑term internships for students.",
    Website = "https://tny-myanmar.com",
    Image = "https://logo.clearbit.com/tny-myanmar.com",
    Address = null,
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = "info@tny-myanmar.com",
    PhoneNumber = null
},

new InternCom
{
    Name = "Global New Wave Technology",
    Industry = "Information Technology",
    Description = "IT company offering 3–6 month software dev internships in cloud, web, mobile.",
    Website = null,
    Image = null,
    Address = "Yangon (office)",
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = null,
    PhoneNumber = null
},

new InternCom
{
    Name = "Myanmar Link",
    Industry = "Internet / Telecom",
    Description = "Fiber‑internet provider offering internships in web, mobile and data analytics.",
    Website = null,
    Image = null,
    Address = "Yangon (office)",
    City = "Yangon",
    Country = "Myanmar",
    OffersInternships = true,
    Email = null,
    PhoneNumber = null
}

                );
                context.SaveChanges();
            }
        }
        private static async Task SeedRolesAndAdmin(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
            // Create roles if they don't exist
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create admin user if it doesn't exist
            const string adminEmail = "admin@example.com";
            const string adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    FullName = "System Administrator",
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            else if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                // Ensure existing admin has the role
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
    