using LabCubes.Data.Entity;
using LabCubes.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabCubes.Data
{
    public class LabCubesDBContext:DbContext
    {
       public DbSet<Person> Persons { get; set; }
       public DbSet<ReportType> ReportTypes { get; set; }
        //public LabCubesDBContext(DbContextOptions<LabCubesDBContext> options) :base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
