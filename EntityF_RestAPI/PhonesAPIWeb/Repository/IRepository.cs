using PhonesAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Repository
{
    public interface IRepository
    {
        List<Phone> GetAll();
        Phone? GetById(int id);
        void Remove(int id);
    }
}
