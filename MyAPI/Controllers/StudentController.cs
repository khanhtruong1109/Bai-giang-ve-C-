using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Dto;
using MyAPI.Entities;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // quản lý thông tin sinh viên  bằng collection List
        public static List<Student> _student = new List<Student>();
        public static int _id;
        /// <summary>
        /// Thêm sinh viên
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(CreateStudentDto input)
        {
            try
            {
                _student.Add(new Student
                {
                    StudentId = input.StudentId,
                    DateOfBirth = input.DateOfBirth,
                    Id = ++_id,
                    StudentName = input.StudentName,
                });
                return Ok(new { message = "Dữ liệu đã được khởi tạo" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Sửa thông tin sinh vien
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public IActionResult Create(int id, CreateStudentDto input)
        {
            try
            {
                var findUser = _student.FirstOrDefault(x => x.Id == id);
                findUser.StudentId = input.StudentId;
                findUser.StudentName = input.StudentName;
                findUser.DateOfBirth = input.DateOfBirth;
                return Ok(new { message = "Dữ liệu đã được cập nhật" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Lấy ra thông tin chi tiết sinh viên
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            try
            {
                return Ok(_student.FirstOrDefault(sv => sv.Id == id));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Xóa thông tin sinh viên theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("remove/{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _student.Remove(_student.FirstOrDefault(user => user.Id == id));
                return Ok("Dữ liệu đã được xóa");
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }
    }
}
