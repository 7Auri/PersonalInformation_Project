using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalInformation.Models
{
    public class PersonalDbContext:DbContext
    {
        public PersonalDbContext(DbContextOptions<PersonalDbContext> options) : base(options)
        { }

        public DbSet<Person> Personz { get; set; }
    }
}
