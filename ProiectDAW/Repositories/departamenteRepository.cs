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

        public void InsertDepartament(departamente departamente)
        {
            _context.departamentes.Add(departamente);
            Save();
        }

        public void DeleteDepartament(int IdDepartament)
        {
            departamente departamente = _context.departamentes.Find(IdDepartament);
            _context.departamentes.Remove(departamente);
            Save();
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


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
