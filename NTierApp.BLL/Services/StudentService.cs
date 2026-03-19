using Microsoft.EntityFrameworkCore;
using NTierApp.Core.Models;
using NTierApp.DAL.Contexts;

namespace NTierApp.BLL.Services
{
    public class StudentService : NTierApp.Core.Interfaces.IStudentInterface
    {
        public async Task<Student> AddStudentAsync(Student student)
        {
            AppDBContext dbContext = new AppDBContext();
            if (student != null)
            {
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Student added successfully.");
                return student;
            }else throw new Exception("Student cannot be null");
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
