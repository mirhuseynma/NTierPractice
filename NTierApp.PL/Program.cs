using NTierApp.BLL.Services;
using NTierApp.Core.Models;

Student student = new Student
{
    Name = "Mirhuseyn",
    Surname = "Abdullazade",
    Age = 21,
    Email = "zade@example.com",
    DateOfBirth = new DateTime(2002, 07, 06)
};

StudentService studentService = new StudentService();

#region add student
//await studentService.AddStudentAsync(student);
#endregion add student

#region get student by id
//var studentById = await studentService.GetStudentByIdAsync(Guid.Parse("24b03ed9-1123-f111-aa6c-e86f38b50118"));
//Console.WriteLine($"Name: {studentById.Name}, Surname: {studentById.Surname}, Age: {studentById.Age}, Email: {studentById.Email}, DateOfBirth: {studentById.DateOfBirth}");
#endregion

#region get students by name
//var studentsByName = await studentService.GetStudentsByNameAsync("John");
//studentsByName.ForEach(s => Console.WriteLine($"Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Email: {s.Email}, DateOfBirth: {s.DateOfBirth}"));
#endregion

#region update students
//var updateStudent = await studentService.UpdateStudentAsync(Guid.Parse("bd698f7a-1523-f111-aa6c-e86f38b50118"), student);
#endregion

#region delete student
//await studentService.DeleteStudentAsync(Guid.Parse("24b03ed9-1123-f111-aa6c-e86f38b50118"));
#endregion

#region is deleted
//await studentService.IsDeleted(Guid.Parse("bd698f7a-1523-f111-aa6c-e86f38b50118"));
#endregion

#region get all students
studentService.GetAllAsync().Result.ForEach(s =>
{
    Console.WriteLine($"Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Email: {s.Email}, DateOfBirth: {s.DateOfBirth}");
});
#endregion