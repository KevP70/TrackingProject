using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSuiviGeek.Data
{
    public class FollowedContextDesign : IDesignTimeDbContextFactory<FollowedDbContext>
    {
        public FollowedDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            DbContextOptionsBuilder<FollowedDbContext> builder = new DbContextOptionsBuilder<FollowedDbContext>();
            builder.UseSqlServer(configRoot.GetConnectionString("DefaultConnection"));

            return new FollowedDbContext(builder.Options);
        }
    }
}
