using EntityF_proy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.Repository
{
    public interface IRepository
    {
        List<Phone> GetAll();
        Phone? GetById(int id);
        void Remove(int id);
    }
}
