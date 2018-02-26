namespace InsurancePolicy.Core
{
    public class Request
    {
        public int Id { get; set; }

        public string ClientId { get; set; }

        public int InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }
    }
}
