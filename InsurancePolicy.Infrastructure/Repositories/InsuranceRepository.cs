namespace InsurancePolicy.Infrastructure.Repositories
{    
    using System.Collections.Generic;
    using System.Linq;

    using InsurancePolicy.Core;
    using InsurancePolicy.Core.Interfaces;

    public class InsuranceRepository : IInsuranceRepository
    {
        InsuranceContext context = new InsuranceContext();

        public void Add(Insurance insurance)
        {
            context.Insurances.Add(insurance);
            context.SaveChanges();
        }

        public void Edit(Insurance insurance)
        {
            context.Entry(insurance).State = System.Data.Entity.EntityState.Modified;
        }

        public Insurance FindById(int id)
        {
            var result = (from i in context.Insurances where i.Id == id select i).FirstOrDefault();
            return result;
        }

        public IEnumerable<Insurance> GetInsurances()
        {
            return context.Insurances;
        }

        public void Remove(int id)
        {
            Insurance insurance = context.Insurances.Find(id);
            context.Insurances.Remove(insurance);
            context.SaveChanges();
        }
    }
}
