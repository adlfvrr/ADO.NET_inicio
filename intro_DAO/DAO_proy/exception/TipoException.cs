using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.exception
{
    public class TipoException : ApplicationException
    {
        public TipoException() : base("El tipo de celular no es válido.")
        {

        }
    }
}
