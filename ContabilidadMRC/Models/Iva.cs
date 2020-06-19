using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilidadMRC.Models
{
    public class Iva
    {
        //Properties Definition

        [Key]
        public int IvaID { get; set; }

        [Display(Name = "Valor (%)")]
        [Range(0, 100, ErrorMessage = "Su valor está medido en porcentaje debe estar entre 0 y 100")]
        [Required]
        public int Value { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string Description { get; set; }

        //Navigation Properties Definition
        public ICollection<TypeProduct> TypeProducts { get; set; }
    }
}
