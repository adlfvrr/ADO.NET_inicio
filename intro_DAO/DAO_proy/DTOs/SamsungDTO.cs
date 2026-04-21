using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.DTOs
{
    public class SamsungDTO : CelularBaseDTO
    {
        public string model { get; set; } = string.Empty;
        public double precio { get; set; }
        public string serie { get; set; } = string.Empty;

        public SamsungDTO()
        {

        }

        public override string ToString()
        {
            return $"============Samsung================\nModelo: {this.model} - Existencias: {this.stock} |\n Precio: ${this.precio:f2} - Serie: {this.serie}\n==================================";
        }
    }
}
    