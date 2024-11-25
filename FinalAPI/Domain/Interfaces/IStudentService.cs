using FinalAPI.DAL.Entities;
using System.Diagnostics.Metrics;

namespace FinalAPI.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync(); 

        Task<Student> CreateStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(Guid id);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(Guid id);

    }
}
