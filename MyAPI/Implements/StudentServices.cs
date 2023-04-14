using MyAPI.Dto;
using MyAPI.Entities;
using MyAPI.Interfaces;

namespace MyAPI.Implements
{
    public class StudentServices : IStudentServices
    {
        // quản lý thông tin sinh viên  bằng collection List
        public static List<Student> _student = new List<Student>();
        public static int _id;
        public void CreateStudent(CreateStudentDto input)
        {
            _student.Add(new Student
            {
                StudentId = input.StudentId,
                DateOfBirth = input.DateOfBirth,
                Id = ++_id,
                StudentName = input.StudentName,
            });
        }

        public List<Student> GetStudent()
        {
            return _student;
        }

        public void RemoveStudent(int id)
        {
            var student = _student.FirstOrDefault(x => x.Id == id);
            _student.Remove(student);
        }

        public void UpdateStudent(int id, CreateStudentDto input)
        {
            var findUser = _student.FirstOrDefault(x => x.Id == id);
            findUser.StudentId = input.StudentId;
            findUser.StudentName = input.StudentName;
            findUser.DateOfBirth = input.DateOfBirth;
        }
    }
}
