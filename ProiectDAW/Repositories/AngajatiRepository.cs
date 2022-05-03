﻿using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;

namespace ProiectDAW.Repositories
{
    public class AngajatiRepository : IAngajatiRepository
    {
        private readonly ProiectDAWcontext _context;
        public AngajatiRepository(ProiectDAWcontext context)
        {
            _context = context;
        }

        public ICollection<detaliiAngajati>GetAngajati()
        {
            return _context.detaliiAngajatis.OrderBy(p => p.IdAngajat).ToList();
        }

        public detaliiAngajati GetAngajatiById(int IdAngajat)
        {
            return _context.detaliiAngajatis.Where(p => p.IdAngajat == IdAngajat).FirstOrDefault();
        }

        //public detaliiAngajati GetAngajatiByNume(string nume)
        //{
            //return context.detaliiAngajatis.Find(nume);
        //}

        public void InsertAngajati(detaliiAngajati detaliiAngajati)
        {
            _context.detaliiAngajatis.Add(detaliiAngajati);
            Save();
        }

        public void DeleteAngajati(int IdAngajat)
        {
            detaliiAngajati detaliiAngajati = _context.detaliiAngajatis.Find(IdAngajat);
            _context.detaliiAngajatis.Remove(detaliiAngajati);
            Save();
        }

        public void UpdateAngajati(detaliiAngajati detaliiAngajati)
        {
            _context.detaliiAngajatis.Update(detaliiAngajati);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
