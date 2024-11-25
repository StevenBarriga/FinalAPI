using FinalAPI.DAL;
using FinalAPI.DAL.Entities;
using FinalAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FinalAPI.Domain.Services
{
    public class StudentService : IStudentService
    {

        private readonly DataBaseContext _context;
        public StudentService(DataBaseContext context)
        {
            _context = context;
        }

        //continuar aqui 
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            try
            {
                //var students = await _context.Students.Include(a => a.Asignatures).ToListAsync();
                var students = await _context.Students.ToListAsync();
                return students;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.id == id);
                return student;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            try
            {
                student.id = Guid.NewGuid();
                student.CreatedDate = DateTime.Now;

                _context.Students.Add(student); 
                await _context.SaveChangesAsync(); 

                return student;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            try
            {
                student.ModifiedDate = DateTime.Now;
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Student> DeleteStudentAsync(Guid id)
        {
            try
            {
                var student = await GetStudentByIdAsync(id);
                if (student == null)
                {
                    return null;
                }
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }     
    }
}
