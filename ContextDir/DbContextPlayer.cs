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
        public DbSet<Client> Client { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public DbSet<PostalCodes> PostalCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyDecimalPrecision(18, 2);
            // relation one to one
            modelBuilder.Entity<TaxPlayer>()
           .HasOne(tp => tp.Spouse)
           .WithOne(s => s.TaxPlayer)
           .HasForeignKey<Spouse>(s => s.TaxplayerId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TaxPlayer>().HasOne(s => s.Address).WithOne(t => t.TaxPlayer)
            .HasForeignKey<Address>(a => a.TaxplayerId);

            modelBuilder.Entity<City>().HasOne(s => s.State).WithMany(t => t.City)
         .HasForeignKey(a => a.StateId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SecurityQuestions>(q =>
            {
                q.HasKey(x => x.QuestionID);
                q.HasData(
    new SecurityQuestions { QuestionID = 1, QuestionText = "What is the name of your first best friend?" },
    new SecurityQuestions { QuestionID = 2, QuestionText = "What is the name of the street you grew up on?" },
    new SecurityQuestions { QuestionID = 3, QuestionText = "What was the name of your first pet?" },
    new SecurityQuestions { QuestionID = 4, QuestionText = "What was your grandparent’s nickname?" },
    new SecurityQuestions { QuestionID = 5, QuestionText = "In what city were you born?" },
    new SecurityQuestions { QuestionID = 6, QuestionText = "What was the first concert you attended?" },
    new SecurityQuestions { QuestionID = 7, QuestionText = "What was your favorite childhood food?" },
    new SecurityQuestions { QuestionID = 8, QuestionText = "What was the name of your favorite elementary school teacher?" },
    new SecurityQuestions { QuestionID = 9, QuestionText = "Where did you spend your first vacation?" },
    new SecurityQuestions { QuestionID = 10, QuestionText = "What is the title of your all-time favorite movie?" });

            });




        }



    }
}