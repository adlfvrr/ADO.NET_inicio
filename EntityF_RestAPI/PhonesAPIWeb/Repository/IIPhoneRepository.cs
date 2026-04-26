using PhonesAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Repository
{
    public interface IIPhoneRepository
    {
        Iphone Add(Iphone iphone, Phone phone);
        List<Iphone> GetAll();
        void Update(Iphone iphone, Phone phone);
    }
}
