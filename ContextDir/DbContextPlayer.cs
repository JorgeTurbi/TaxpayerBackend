using Microsoft.EntityFrameworkCore;
using refund.Models;
using refund.Utilities;

namespace refund.ContextDir
{
    public class DbContextPlayer : DbContext
    {

        public DbContextPlayer(DbContextOptions<DbContextPlayer> options) : base(options)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<FilingStatus> FilingStatus { get; set; }
        public DbSet<TaxPlayer> TaxPlayer { get; set; }
        public DbSet<Spouse> Spouse { get; set; }
        public DbSet<Dependents> Dependents { get; set; }
        public DbSet<IncomeType> IncomeType { get; set; }
        public DbSet<TaxPreparer> TaxPreparer { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyDecimalPrecision(18, 2);
            // relation one to one
         modelBuilder.Entity<TaxPlayer>()
        .HasOne(tp => tp.Spouse)
        .WithOne(s => s.TaxPlayer)
        .HasForeignKey<Spouse>(s => s.TaxplayerId)
        .OnDelete(DeleteBehavior.NoAction); 
                
                  modelBuilder.Entity<TaxPlayer>().HasOne(s=>s.Address).WithOne(t=>t.TaxPlayer)
            .HasForeignKey<Address>(a=>a.TaxplayerId);

               modelBuilder.Entity<City>().HasOne(s=>s.State).WithMany(t=>t.City)
            .HasForeignKey(a=>a.StateId).OnDelete(DeleteBehavior.NoAction);

           
              
        }


    }
}