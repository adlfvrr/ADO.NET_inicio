using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.DTO
{
    public class PhoneDTO
    {

        public int Id { get; set; }
        public int Tipo { get; set; } 
        public string Name
        {
            get
            {
                if(Tipo == 1)
                {
                    return "Iphone";
                }
                else
                {
                    return "Samsung";
                }
            }
        }
        public int? Stock { get; set; }

        public PhoneDTO()
        {

        }

    }
}
