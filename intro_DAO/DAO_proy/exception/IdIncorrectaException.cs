using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.exception
{
    public class IdIncorrectaException : ApplicationException
    {
        public IdIncorrectaException(int id) : base($"El id {id} tiene que ser mayor a 0") { }
    }
}
