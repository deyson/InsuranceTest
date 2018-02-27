namespace InsurancePolicy.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using InsurancePolicy.Core.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Insurance : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name="Nombre")]

        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Póliza")]
        [JsonConverter(typeof(StringEnumConverter))]
        public InsuranceTypeEnum Type { get; set; }

        [Display(Name = "Cubrimiento")]
        public decimal Coverage { get; set; }

        [Display(Name = "Inicio de vigencia")]
        [DataType(DataType.Date)]
        public DateTime Validity { get; set; }

        [Display(Name = "Periodo de la cobertura (meses)")]
        public int Period { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Tipo de riesgo")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RiskEnum Risk { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Risk == RiskEnum.High && Coverage > 50)
                yield return new ValidationResult("El porcentaje de cubrimiento no puede ser superior al 50% cuando el tipo de riesgo es alto.");
        }
    }

}
