using Microsoft.EntityFrameworkCore;
using NTierApp.Core.Models;
using NTierApp.DAL.Contexts;

namespace NTierApp.BLL.Services
{
    public class StudentService : NTierApp.Core.Interfaces.IStudentInterface
    {
        private readonly GroupService groupService;
        public async Task<List<Student>> AddStudentAsync(List<Student> students)
        {
            AppDBContext dbContext = new AppDBContext();

            if (students == null)
                throw new Exception("Students cannot be null");

            // Group students by GroupId
            var groupedStudents = students.GroupBy(s => s.GroupId);

            foreach (var group in groupedStudents)
            {
                var groupId = group.Key;
                if (groupId == null)
                    throw new Exception("Students must have a valid GroupId");

                var existingGroup = await dbContext.Groups.FindAsync(groupId);
                if (existingGroup == null)
                    throw new Exception($"Group with ID {groupId} not found");

                // Get current student count in this group
                var currentStudentCount = await dbContext.Students
                    .Where(s => s.GroupId == groupId && !s.IsDeleted)
                    .CountAsync();

                var newStudentsCount = group.Count();

                // Check if adding new students exceeds group's student count limit
                if (currentStudentCount + newStudentsCount > existingGroup.StudentCount)
                    throw new Exception($"Cannot add {newStudentsCount} students to group '{existingGroup.Name}'. Current: {currentStudentCount}, Limit: {existingGroup.StudentCount}");
            }

            await dbContext.Students.AddRangeAsync(students);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Students added successfully.");
            return students;
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            AppDBContext dbContext = new AppDBContext();
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Student deleted successfully.");
            }else throw new Exception("Student not found.");
        }

        public async Task<List<Student>> GetAllAsync()
        {
            
                Student student;
                AppDBContext read = new AppDBContext();
                var students = await read.Students.AsNoTracking().ToListAsync();
                if (students.Any(s => !s.IsDeleted)) return students.Where(s => !s.IsDeleted).ToList();
                else throw new Exception("No students found.");
            
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            AppDBContext dbContext = new AppDBContext();
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (student != null)
            {
                return student;
            }
            else
            {
                throw new Exception("Student not found.");
            }
        }

        public async Task<List<Student>> GetStudentsByNameAsync(string name)
        {
            AppDBContext dbContext = new AppDBContext();
            var students = await dbContext.Students.Where(s => s.Name == name).ToListAsync();
            return students;
        }

        public Task<Student> IsDeleted(Guid id)
        {
            var dbContext = new AppDBContext();
            var student = dbContext.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if(student != null && !student.IsDeleted)
            {
                student.IsDeleted = true;
                student.DeletedAt = DateTime.Now;
                dbContext.Students.Update(student);
                dbContext.SaveChanges();
                Console.WriteLine("Student marked as deleted.");
                return Task.FromResult(student);

            }
            else throw new Exception("Student not found.");

        }

        public async Task<Student> UpdateStudentAsync(Guid id, Student student)
        {
            AppDBContext dbContext = new AppDBContext();
            var existingStudent = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Surname = student.Surname;
                existingStudent.Age = student.Age;
                existingStudent.Email = student.Email;
                existingStudent.DateOfBirth = student.DateOfBirth;
                dbContext.Students.Update(existingStudent);
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Student updated successfully.");
                return existingStudent;
            }
            else throw new Exception("Student not found.");
            
        }
    }
}
