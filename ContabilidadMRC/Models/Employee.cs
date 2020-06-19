using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilidadMRC.Models
{
    public class Employee
    {
        //Properties Definition

        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Cedula")]
        [Required]
        public int IdCard { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres especiales no permitidos")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres especiales no permitidos")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Telefono")]
        [Required]
        public int Phone { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Nombre de usuario")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Caracteres especiales no permitidos")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "Debe estar entre 5 y 255 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Navigation Properties Definition

        public ICollection<Bill> Bills { get; set; }
    }
}
