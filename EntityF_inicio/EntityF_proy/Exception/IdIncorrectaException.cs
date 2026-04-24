using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.Exception
{
    public class IdIncorrectaException : ApplicationException
    {
        public IdIncorrectaException(int id) : base($"El id {id} es incorrecto.") { }

    }
}
