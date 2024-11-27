using FinalAPI.DAL.Entities;
using FinalAPI.Domain.Interfaces;

namespace FinalAPI.Domain.Services
{
    public class SubjectService : ISubjectService
    {
        public Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> GetSubjectByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<Subject> CreateSubjectAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> UpdateSubjecttAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> DeleteSubjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
