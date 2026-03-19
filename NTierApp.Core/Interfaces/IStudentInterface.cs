

using NTierApp.Core.Models;

namespace NTierApp.Core.Interfaces
{
    public interface IStudentInterface
    {
        public Task<List<Student>> AddStudentAsync(List<Student> students);
        public Task<Student> UpdateStudentAsync(Guid id, Student student);
        public Task DeleteStudentAsync(Guid id);
        public Task<Student> IsDeleted(Guid id);
        public Task<Student> GetStudentByIdAsync(Guid id);
        public Task<List<Student>> GetStudentsByNameAsync(string name);
        public Task<List<Student>> GetAllAsync();
    }
}
