using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUV.EntityframeworkCore.WebSample
{
    public class SampleDbContext:DbContext        
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
