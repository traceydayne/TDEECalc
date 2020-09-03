using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TDEECalc.Models;

namespace TDEECalc.Data
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {

        }
    }
}
