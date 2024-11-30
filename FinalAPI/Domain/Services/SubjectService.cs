using FinalAPI.DAL;
using FinalAPI.DAL.Entities;
using FinalAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalAPI.Domain.Services
{
    public class SubjectService :ISubjectService
    {
        private readonly DataBaseContext _context;
        public SubjectService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            try
            {
                var subjects = await _context.Subjects.ToListAsync();
                return subjects;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByStudentIdAsync(Guid id)
        {
            try
            {
                var subjects = await _context.Subjects.Where(s => s.StudentId == id).ToListAsync();
                return subjects;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Subject> GetSubjectByIdAsync(Guid id)
        {
            try
            {
                var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.id == id);
                return subject;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            try
            {
                subject.id = Guid.NewGuid();
                subject.CreatedDate = DateTime.Now;

                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

                return subject;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            try
            {
                subject.ModifiedDate = DateTime.Now;
                _context.Subjects.Update(subject);
                await _context.SaveChangesAsync();
                return subject;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Subject> DeleteSubjectAsync(Guid id)
        {
            try
            {
                var subject = await GetSubjectByIdAsync(id);
                if (subject == null)
                {
                    return null;
                }
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                return subject;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}
