using Microsoft.AspNetCore.Mvc;
using MyAPI.Dto;
using MyAPI.Entities;

namespace MyAPI.Interfaces
{
    public interface IStudentServices
    {
        public void CreateStudent(CreateStudentDto input);

        public void UpdateStudent(int id, CreateStudentDto input);
        public List<Student> GetStudent();

        public void RemoveStudent(int id);
    }
}
