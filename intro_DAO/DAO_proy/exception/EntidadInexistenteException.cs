using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.exception
{
    public class EntidadInexistenteException : ApplicationException
    {
        public EntidadInexistenteException() : base("La entidad no existe") { }
    }
}
