using PhonesAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Repository
{
    public interface ISamsungRepository
    {
        Samsung Add(Samsung samsung, Phone phone);
        List<Samsung> GetAll();
        void Update(Samsung samsung, Phone phone);
    }
}
