using FinalAPI.DAL.Entities;

namespace FinalAPI.Domain.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();

        Task<IEnumerable<Subject>> GetSubjectsByStudentIdAsync(Guid id);

        Task<Subject> CreateSubjectAsync(Subject subject);
        Task<Subject> GetSubjectByIdAsync(Guid id);
        Task<Subject> UpdateSubjectAsync(Subject subject);
        Task<Subject> DeleteSubjectAsync(Guid id);

    }
}

