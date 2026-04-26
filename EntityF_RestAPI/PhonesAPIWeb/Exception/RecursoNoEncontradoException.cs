using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Exception
{
    public class RecursoNoEncontradoException : ApplicationException
    {
        public RecursoNoEncontradoException() : base("No se encontró el phone") { }
    }
}
