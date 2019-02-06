using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tour.Heroes.Api
{
    public class HeroDbContextFactory : IDesignTimeDbContextFactory<HeroDbContext>
    {
        public HeroDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HeroDbContext>();
            var connectionString = Utility.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new HeroDbContext(builder.Options);
        }
    }
}