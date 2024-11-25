﻿using FinalAPI.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FinalAPI.Domain.Interfaces
{
    public interface IStudentService
    {
        /*get by id, get all, create, update, delete*/ //operaciones basicas en las API
        Task<IEnumerable<Student>> GetCountriesAsync(); // on esto se busca listar todos los paises

        Task<Student> CreateStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(Guid id);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(Guid id);

    }
}