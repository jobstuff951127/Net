using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Net.Models;

namespace Net.Data
{
    public partial class NetContext : DbContext
    {
        public NetContext()
        {

        }
        public NetContext(DbContextOptions<NetContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<QuestionTag> QuestionTags { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

    }
}

