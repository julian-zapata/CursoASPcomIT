using System;
using MyComercio.Data;
using MyComercio.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class BasePersona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]   //Data Annotation
        [StringLength(12, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Fecha requerida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [ValidationDateBirth(ErrorMessage = "Fecha no válida")]
        [ValidationDateBirthMinimun(ErrorMessage = "Fecha minima es de 120 años")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Teléfono", Prompt = "ej. 3512006484")]
        //buscar la validacion del telefono
        public string Telefono { get; set; }

        public int IdPais { get; set; }

        public int IdCiudad { get; set; }

        public Pais GetPais()
        {
            Pais pais;
            using(var context = new MyComercioContext())
            {
                pais = context.Pais.Where(x => x.Id == IdPais).FirstOrDefault();
            }

            return pais;
        }

        public Ciudad GetCiudad()
        {
            Ciudad ciudad;
            using(var context = new MyComercioContext())
            {
                ciudad = context.Ciudad.Where(x => x.Id == IdCiudad).FirstOrDefault();
            }

            return ciudad;
        }

    }
}
