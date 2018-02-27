namespace InsurancePolicy.Infrastructure
{
    using System.Data.Entity;
    using InsurancePolicy.Core;

    public class InsuranceContext : DbContext 
    {
        public InsuranceContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InsuranceContext>());
            InsuranceInitializeDB db = new InsuranceInitializeDB();
            Database.SetInitializer(db);
        }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
