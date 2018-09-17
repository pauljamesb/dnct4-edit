using DNCT5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DNCT5.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Items.Any())
                {
                    return;   // DB has been seeded
                }

                context.Items.AddRange(
                    new Item
                    {
                        Name = "When Harry Met Sally"
                    },
                    new Item
                    {
                        Name = "Ghostbusters"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}