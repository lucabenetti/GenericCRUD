using GenericDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext()
        {
        }
        
        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(GenericDbContext).Assembly);
        }

        public DbSet<Person> Person { get; set; }
    }
}
