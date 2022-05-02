﻿using ProiectDAW.Models;
namespace ProiectDAW.Interfaces
{
    public interface IdepartamenteRepository
    {
        ICollection<departamente> GetDepartament();
        departamente GetDepartamentById(int IdDepartament);
        void InsertDepartament(departamente departamente);
        void DeleteDepartament (int IdDepartament);
        void UpdateDepartament(departamente departamente);
        void Save();

    }
}