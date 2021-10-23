using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Persistence
{
    /// <summary>
    /// Factory necessary for EF for design time functionalities
    /// </summary>
    public class ImagegramDbContextFactory : IDesignTimeDbContextFactory<ImagegramDbContext>
    {
        public ImagegramDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImagegramDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new ImagegramDbContext(optionsBuilder.Options);
        }
    }
}
