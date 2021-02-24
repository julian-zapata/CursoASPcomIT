using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Ciudad
    {

        public Ciudad()
        {

        }

        [Key]
        public int Id { get; set; }

        public int IdPais { get; set; }

        [Required]
        [MaxLength(70)]
        public string Descripcion { get; set; }

        public Pais GetPais()
        {
            Pais pais;
            using(var context = new MyComercioContext())
            {
                pais = context.Pais.Where(x => x.Id == IdPais).FirstOrDefault();
            }

            return pais;
        }
    }
}
