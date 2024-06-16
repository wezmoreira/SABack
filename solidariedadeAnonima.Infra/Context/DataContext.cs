using Microsoft.EntityFrameworkCore;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Infra.Context.Mappings;

namespace solidariedadeAnonima.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CardPrincipal> CardPrincipals { get; set; }
        public DbSet<Comments> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());
            modelBuilder.ApplyConfiguration(new AnswersMap());

        }
    }
}
