using NTierApp.BLL.Services;
using NTierApp.Core.Models;

List<Student> students = new List<Student>
{
   new Student { Name = "James", Surname = "David", Age = 26, Email = "james.david@example.com", DateOfBirth = new DateTime(1998, 5, 15), GroupId = Guid.Parse("a1e5ab4f-c95c-43ed-6390-08de85b96565") },
};

List<Group> groups = new List<Group>
{
    new Group { Name = "Group A", StudentCount = 2, Description = "Description for Group A" },
    new Group { Name = "Group B", StudentCount = 2, Description = "Description for Group B" }

};

StudentService studentService = new StudentService();
GroupService groupService = new GroupService();

#region Add groups
//await groupService.CreateGroupAsync(groups);
#endregion

#region add student
await studentService.AddStudentAsync(students);
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
//await studentService.IsDeleted(Guid.Parse("bf1ad904-7523-f111-aa6c-e86f38b50118"));
#endregion

#region get all students
//try
//{
//    studentService.GetAllAsync().Result.ForEach(s =>
//    {
//        Console.WriteLine($"Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Email: {s.Email}, DateOfBirth: {s.DateOfBirth}");
//    });
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion