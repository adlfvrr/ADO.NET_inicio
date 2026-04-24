using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.DTO
{
    public class SamsungDTO : PhoneDTO
    {

        public string? Model { get; set; } = string.Empty;
        public decimal? Precio { get; set; }
        public string? Serie { get; set; } = string.Empty;

        public SamsungDTO()
        {

        }

        public override string ToString()
        {
            return $"============Samsung================\nModelo: {this.Model} - Existencias: {this.Stock} |\n Precio: ${this.Precio:f2} - Serie: {this.Serie}\n==================================";
        }

    }
}
