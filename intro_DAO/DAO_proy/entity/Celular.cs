using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.entity
{
    public class Celular
    {
        public int id { get; set; }
        public int type { get; set; }
        public int stock { get; set; }

        public Celular(int id, int type, int stock)
        {
            this.id = id;
            this.type = type;
            this.stock = stock;
        }

        public Celular()
        {

        }

    }
}
