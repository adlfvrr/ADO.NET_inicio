using EntityF_proy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.Repository
{
    public interface ISamsungRepository
    {
        Samsung Add(Samsung samsung, Phone phone);
        List<Samsung> GetAll();
        void Update(Samsung samsung, Phone phone);
    }
}
