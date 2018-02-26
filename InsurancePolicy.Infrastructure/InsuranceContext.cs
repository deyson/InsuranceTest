namespace InsurancePolicy.Infrastructure
{
    using System.Data.Entity;
    using InsurancePolicy.Core;

    public class InsuranceContext : DbContext 
    {
        public InsuranceContext()
        {
        }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
