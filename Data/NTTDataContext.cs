using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NTT_Data.Models;

namespace NTT_Data.Data
{
    public partial class NTTDataContext : DbContext
    {
        public NTTDataContext()
        {

        }
        public NTTDataContext(DbContextOptions<NTTDataContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Concept> Concept { get; set; }

    }
}

