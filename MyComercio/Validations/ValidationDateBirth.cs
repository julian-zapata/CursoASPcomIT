using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Validations
{
    public class ValidationDateBirth : ValidationAttribute
        //Clase para crear una propia validacion
    {
        override
        public bool IsValid(object value)
        {
            //el parametro value es una fecha de nacimiento
            var DateBirth = (DateTime)value;

            if (DateBirth > DateTime.Now )
            {
                return false;
            }

            return true;

            
        }
    }

    public class ValidationDateBirthMinimun : ValidationAttribute
    //Clase para crear una propia validacion
    {
        override
        public bool IsValid(object value)
        {
            //el parametro value es una fecha de nacimiento
            var DateBirth = (DateTime)value;

            if (DateBirth < DateTime.Now.AddYears(-120))
            {
                return false;
            }

            return true;

        }
    }
}
