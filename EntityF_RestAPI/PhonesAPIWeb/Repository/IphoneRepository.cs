using PhonesAPIWeb.Data;
using PhonesAPIWeb.Exception;
using PhonesAPIWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Repository
{
    public class IphoneRepository : IIPhoneRepository
    {
        private readonly CelularesDbContext _context;

        public IphoneRepository(CelularesDbContext context)
        {
            this._context = context;
        }

        public Iphone Add(Iphone iphone, Phone phone)
        {
            //Primero guardamos el teléfono en tabla phones, de esta manera, podemos conseguir su id generado
            _context.Phones.Add(phone);
            _context.SaveChanges();

            //Ahora guardamos el IPhone
            iphone.IdPhone = phone.IdPhone;

            _context.Iphones.Add(iphone);
            _context.SaveChanges();

            return iphone;
        }

        public List<Iphone> GetAll()
        {
            return _context.Iphones
                .Include(i => i.IdPhoneNavigation)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Iphone iphone, Phone phone)
        {
            Iphone i = _context.Iphones.Find(iphone.IdPhone);
            Phone p = _context.Phones.Find(phone.IdPhone);

            if (i == null || p == null)
            {
                throw new RecursoNoEncontradoException();
            }
            i.Model = iphone.Model;
            i.Price = iphone.Price;
            i.CondBateria = iphone.CondBateria;
            p.Stock = phone.Stock;

            _context.SaveChanges();
        }

    }
}

