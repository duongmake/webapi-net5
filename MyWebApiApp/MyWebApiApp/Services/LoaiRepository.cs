using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;

        public LoaiRepository(MyDbContext context) 
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var loais = new Loai
            {
                TenLoai = loai.TenLoai
            };
            _context.Add(loais);
            _context.SaveChanges();

            return new LoaiVM
            {
                MaLoai = loais.MaLoai,
                TenLoai = loais.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai
            });
            return loais.ToList();
        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;
        }

        public void Update(LoaiVM loai)
        {
            var loais = _context.Loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            loai.TenLoai = loai.TenLoai;
            _context.SaveChanges();
        }
    }
}
