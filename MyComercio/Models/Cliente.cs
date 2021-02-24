using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Cliente : BasePersona  // Clase: ClasePadre para aplicar herencia
    {
        [Display(Name = "e-mail", Prompt = "pepito@mail.com")]
        [RegularExpression("^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$",
            ErrorMessage = "e-mail incorrecto")]
        [MaxLength(25)]
        public string Mail { get; set; }
       

       
    }
}
