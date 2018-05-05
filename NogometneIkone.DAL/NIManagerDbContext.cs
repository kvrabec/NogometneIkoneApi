using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NogometneIkone.Model;

namespace NogometneIkone.DAL
{
    public sealed class NIManagerDbContext : IdentityDbContext<AppUser>
    {
        public NIManagerDbContext() : base(){}
        public NIManagerDbContext(DbContextOptions<NIManagerDbContext> dbContext) : base(dbContext) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("");
        //}

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
         
    }
}
