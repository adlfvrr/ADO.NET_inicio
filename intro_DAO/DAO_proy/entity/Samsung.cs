using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.entity
{
    public class Samsung : Celular
    {
        public string model { get; set; }
        public double price { get; set; }
        public string serie { get; set; }

        public Samsung(int id, int type, int stock, string model, double price, string serie) : base(id, type, stock)
        {
            this.model = model;
            this.price = price;
            this.serie = serie;
        }

        public Samsung()
        {

        }
    }
}
