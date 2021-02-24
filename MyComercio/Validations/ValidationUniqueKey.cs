﻿using MyComercio.Data;
using MyComercio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Validations
{
    public class ValidationUniqueKey : ValidationAttribute
    {

        

        public override bool IsValid(object value)
        {
            Pais pais;

            using (var context = new MyComercioContext())
            {
                pais = context.Pais.Where(x => x.Description.Trim().ToUpper() == value.ToString().Trim().ToUpper()).FirstOrDefault();
            }

            var ret = (pais == null);
            
            return ret;
        }
    }
}
