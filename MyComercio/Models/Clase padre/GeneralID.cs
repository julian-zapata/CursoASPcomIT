using MyComercio.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models.Clase_padre
{
    public class GeneralID
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        [ValidationUniqueKey(ErrorMessage = "Elemento ya existente")]
        public string Descripcion { get; set; }

    }
}
