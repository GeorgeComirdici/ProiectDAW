using ProiectDAW.Models;
using ProiectDAW.Interfaces;
using ProiectDAW.data;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ProiectDAW.Repositories
{
    public class departamenteRepository : IdepartamenteRepository
    {
        private readonly ProiectDAWcontext _context;
        public departamenteRepository(ProiectDAWcontext context)
        {
            _context = context;
        }

        public ICollection<departamente> GetDepartament()
        {
            return _context.departamentes.OrderBy(p => p.IdDepartament).ToList();
        }

        public bool InsertDepartament(departamente departamente)
        {
            _context.Add(departamente);
            return Save();
        }

        public bool DeleteDepartament(departamente departamente)
        {
            _context.Remove(departamente);
            return Save();
        }

        public void UpdateDepartament(departamente departamente)
        {
            _context.departamentes.Update(departamente);
            Save();
        }

        public departamente GetDepartamentById(int IdDepartament)
        {
            return _context.departamentes.Where(p => p.IdDepartament == IdDepartament).FirstOrDefault();
        }

        //public departamente GetDepartamentByNume(string NumeDepartament)
        //{
          //  return _context.departamentes.Where(p => p.NumeDepartament == NumeDepartament).FirstOrDefault();
        //}

        public bool Save()
        {
            var salvat = _context.SaveChanges();
            return salvat >0 ? true : false;
        }
    }
}
