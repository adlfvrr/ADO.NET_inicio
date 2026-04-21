using DAO_proy.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.DTOs
{
    public class CelularBaseDTO
    {
        //Establecemos el DTO base
        public int id {  get; set; }
        public int tipo { get; set; } //Discriminador
        public int stock { get; set; }

        public CelularBaseDTO()
        {
            
        }
    }
}
