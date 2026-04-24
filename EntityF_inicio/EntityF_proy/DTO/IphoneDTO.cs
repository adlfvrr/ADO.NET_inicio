using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.DTO
{
    public class IphoneDTO : PhoneDTO
    {

        public string? Model { get; set; } = string.Empty;
        public decimal? Precio { get; set; }
        public string? Cond_bateria { get; set; } = string.Empty;

        public IphoneDTO()
        {

        }

        public override string ToString()
        {
            return $"============Iphone================\nModelo: {this.Model} - Existencias: {this.Stock} |\n Precio: ${this.Precio:f2} - Batería: {this.Cond_bateria}\n==================================";
        }

    }
}
