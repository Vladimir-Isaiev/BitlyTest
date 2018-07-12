using BitlyTest.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitlyTest.Repo
{
    public class RecordContext:DbContext
    {
        public DbSet<Record> Records { get; set; }
        public RecordContext(DbContextOptions<RecordContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

