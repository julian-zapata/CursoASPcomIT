using MyComercio.Data;
using MyComercio.Models.Clase_padre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Producto : GeneralID
    { 
        public int IdCategoriaProducto { get; set; }

        [Required]
        //validar el numero decimal
        public int Precio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public CategoriaProducto GetCategoria()
        {
            CategoriaProducto categoria;
            using(MyComercioContext context = new MyComercioContext())
            {
                categoria = context.CategoriaProducto.Where(x => x.Id == IdCategoriaProducto).FirstOrDefault();
            }

            return categoria;
        }
    }
}
