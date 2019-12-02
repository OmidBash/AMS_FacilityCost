using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AMS.WebUI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Set<Unit>().Any())
            {
                context.AddRange(
                        new Unit { Id = Guid.NewGuid(), Name = "واحد یک" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد دو" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد سه" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد چهار" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد پنج" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد شش" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد هفت" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد هشت" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد نه" },
                        new Unit { Id = Guid.NewGuid(), Name = "واحد ده" }
                    );
                context.SaveChanges();
            }
        }
    }
}
