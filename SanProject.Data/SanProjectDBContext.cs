using Microsoft.EntityFrameworkCore;
using SanProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanProject.Data
{
    public class SanProjectDBContext :DbContext
    {
        public SanProjectDBContext(DbContextOptions<SanProjectDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
