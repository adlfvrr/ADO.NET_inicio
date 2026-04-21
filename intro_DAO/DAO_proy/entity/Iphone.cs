using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.entity
{
    public class Iphone : Celular
    {
        public string model { get; set; }
        public double price { get; set; }
        public string cond_bateria { get; set; }
        public Iphone(int id, int type, int stock, string model, double price, string cond_bateria) : base(id, type, stock)
        {
            this.model = model;
            this.price = price;
            this.cond_bateria = cond_bateria;
        }

        public Iphone()
        {

        }
    }
}
