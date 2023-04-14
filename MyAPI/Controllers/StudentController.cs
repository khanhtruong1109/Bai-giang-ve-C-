using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Dto;
using MyAPI.Entities;
using MyAPI.Interfaces;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices) 
        {
            _studentServices = studentServices;
        }
        /// <summary>
        /// Thêm sinh viên
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult Create(CreateStudentDto input)
        {
            try
            {
                _studentServices.CreateStudent(input);
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
        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateStudentDto input)
        {
            try
            {
                _studentServices.UpdateStudent(id, input);
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
        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_studentServices.GetStudent());
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
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _studentServices.RemoveStudent(id);
                return Ok("Dữ liệu đã được xóa");
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }
    }
}
