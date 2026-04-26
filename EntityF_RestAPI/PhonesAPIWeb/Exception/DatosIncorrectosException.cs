using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Exception
{
    public class DatosIncorrectosException : ApplicationException
    {

        public DatosIncorrectosException() : base("Chequear campos.\nSe detectaron campos incorrectos.") { }

    }
}
