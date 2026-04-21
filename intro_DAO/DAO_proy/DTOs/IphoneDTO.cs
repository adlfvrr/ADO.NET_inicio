using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.DTOs
{
    public class IphoneDTO : CelularBaseDTO
    {
        public string model { get; set; } = string.Empty;
        public double precio { get; set; } 
        public string cond_bateria { get; set; } = string.Empty;

        public IphoneDTO() {
        
        }

        public override string ToString()
        {
            return $"============Iphone================\nModelo: {this.model} - Existencias: {this.stock} |\n Precio: ${this.precio:f2} - Batería: {this.cond_bateria}\n==================================";
        }
    }
}
