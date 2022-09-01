using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _272Ass3.Models;

namespace _272Ass3.Data
{
    public class _272Ass3Context : DbContext
    {
        public _272Ass3Context (DbContextOptions<_272Ass3Context> options)
            : base(options)
        {
        }

        public DbSet<_272Ass3.Models.User> User { get; set; } = default!;

        public DbSet<_272Ass3.Models.Seminar>? Seminar { get; set; }
    }
}
