namespace InsurancePolicy.Core.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum InsuranceTypeEnum
    {
        [Display(Name = "Terremoto")]
        Earthquake,
        [Display(Name = "Incendio")]
        Fire,
        [Display(Name = "Pérdida")]
        Lost,
        [Display(Name = "Robo")]
        Stole             
    }
}
