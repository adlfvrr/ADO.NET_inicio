using EntityF_proy.Data;
using EntityF_proy.Exception;
using EntityF_proy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.Repository
{
    public class SamsungRepository : ISamsungRepository
    {

        private readonly CelularesDbContext _context;

        public SamsungRepository(CelularesDbContext context)
        {
            _context = context;
        }

        public Samsung Add(Samsung samsung, Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();

            samsung.IdPhone = phone.IdPhone;

            _context.Samsungs.Add(samsung);
            _context.SaveChanges();

            return samsung;
        }

        public List<Samsung> GetAll()
        {
            return _context.Samsungs
                .Include(s => s.IdPhoneNavigation)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Samsung samsung, Phone phone)
        {
            Samsung s = _context.Samsungs.Find(samsung.IdPhone);
            Phone p = _context.Phones.Find(phone.IdPhone);

            if(s == null  || p == null)
            {
                throw new RecursoNoEncontradoException();
            }
            s.Model = samsung.Model;
            s.Price = samsung.Price;
            s.Serie = samsung.Serie;
            p.Stock = phone.Stock;

            _context.SaveChanges();

        }
    }
}
