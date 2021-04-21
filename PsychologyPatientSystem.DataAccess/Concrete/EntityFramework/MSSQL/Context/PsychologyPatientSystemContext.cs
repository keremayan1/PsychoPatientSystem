using Microsoft.EntityFrameworkCore;
using PsychologyPatientSystem.Core.Entities.Concrete;
using PsychologyPatientSystem.Entities.Concrete;

namespace PsychologyPatientSystem.DataAccess.Concrete.EntityFramework.MSSQL.Context
{
  public  class PsychologyPatientSystemContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PsicoClient;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
