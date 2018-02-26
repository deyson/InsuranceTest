namespace InsurancePolicy.Core.Interfaces
{
    using System.Collections.Generic;

    public interface IInsuranceRepository
    {
        void Add(Insurance insurance);
        void Edit(Insurance insurance);
        void Remove(int id);
        IEnumerable<Insurance> GetInsurances();
        Insurance FindById(int id);
    }
}
