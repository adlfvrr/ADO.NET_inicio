using PhonesAPIWeb.Data;
using PhonesAPIWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace PhonesAPIWeb.Repository
{
    public class PhoneRepository : IRepository
    {

        private readonly CelularesDbContext _context;

        public PhoneRepository(CelularesDbContext context)
        {
            _context = context;
        }

        public List<Phone> GetAll()
        {
            return _context.Phones
                .Include(p => p.Samsung)
                .Include(p => p.Iphone)
                .AsNoTracking()
                .ToList();
        }

        public Phone? GetById(int id)
        {
            return _context.Phones
                .Include(p => p.Samsung)
                .Include(p => p.Iphone)
                .AsNoTracking()
                .FirstOrDefault(p => p.IdPhone == id);
        }

        public void Remove(int id)
        {
            var phone = _context.Phones.Find(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
                _context.SaveChanges();
            }
        }
    }
}
