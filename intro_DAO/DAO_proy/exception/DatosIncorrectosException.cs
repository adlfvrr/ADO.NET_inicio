using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.exception
{
    public class DatosIncorrectosException : ApplicationException
    {
        public DatosIncorrectosException() : base("Los datos ingresados son incorrectos") { }
    }
}
