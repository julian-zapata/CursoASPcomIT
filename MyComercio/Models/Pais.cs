using MyComercio.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        [ValidationUniqueKey(ErrorMessage = "El pais ya existe")]
        public string Description { get; set; }

    }
}
