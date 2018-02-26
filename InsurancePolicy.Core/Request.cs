using System.ComponentModel.DataAnnotations;

namespace InsurancePolicy.Core
{
    public class Request
    {
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public string ClientId { get; set; }

        [Display(Name = "Póliza")]
        public int InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }
    }
}
