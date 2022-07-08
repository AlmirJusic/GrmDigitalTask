using GrmDigitalTask.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrmDigitalTask.EF
{
    public class GrmTaskDbContext:DbContext
    {
        public GrmTaskDbContext(DbContextOptions<GrmTaskDbContext> options) : base(options)
        {
        }

        public DbSet<GrmTask> GrmTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrmTask>().HasData(
                    new GrmTask
                    {
                        ID = 1,
                        Name = "Item1",
                        Score = 0,
                        Position = 0
                    },
                    new GrmTask
                    {
                        ID = 2,
                        Name = "Item2",
                        Score = 0,
                        Position = 0
                    },
                    new GrmTask
                    {
                        ID = 3,
                        Name = "Item3",
                        Score = 0,
                        Position = 0
                    },
                    new GrmTask
                    {
                        ID = 4,
                        Name = "Item4",
                        Score = 0,
                        Position = 0
                    },
                    new GrmTask
                    {
                        ID = 5,
                        Name = "Item5",
                        Score = 0,
                        Position = 0
                    },
                    new GrmTask
                    {
                        ID = 6,
                        Name = "Item6",
                        Score = 0,
                        Position = 0

                    }
                    );
        }
    }
}
