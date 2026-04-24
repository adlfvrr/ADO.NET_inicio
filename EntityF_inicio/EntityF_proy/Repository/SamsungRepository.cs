using EntityF_proy.Data;
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
            _context.Phones.Update(phone);
            _context.Samsungs.Update(samsung);
            _context.SaveChanges();
        }
    }
}
