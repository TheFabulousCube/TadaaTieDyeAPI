using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CatagoryLookup> CatagoryLookup { get; set; }
        public virtual DbSet<Clothing> Clothing { get; set; }
        public virtual DbSet<Downloads> Downloads { get; set; }
        public virtual DbSet<Magnets> Magnets { get; set; }
        public virtual DbSet<RoleLookup> RoleLookup { get; set; }
        public virtual DbSet<SizeLookup> SizeLookup { get; set; }
        public virtual DbSet<SleeveLookup> SleeveLookup { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
