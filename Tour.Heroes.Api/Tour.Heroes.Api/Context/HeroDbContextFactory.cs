using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api.Context
{
    public class HeroDbContextFactory : IDesignTimeDbContextFactory<HeroDbContext>
    {
        public HeroDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HeroDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new HeroDbContext(builder.Options);
        }

        public HeroDbContext CreateDbContextByConnectionString(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<HeroDbContext>();

            builder.UseSqlServer(connectionString);

            return new HeroDbContext(builder.Options);
        }
    }
}