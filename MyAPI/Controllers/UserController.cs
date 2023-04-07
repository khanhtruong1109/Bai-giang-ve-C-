using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Dto;
using MyAPI.Entities;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> _user = new List<User>();
        public static int _id;
        /// <summary>
        /// Tạo user mới 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(CreateUserDto input)
        {
            _user.Add(new User { 
                Name = input.Name,
                Email = input.Email,
                Id = ++_id ,
                Password = input.Password,
            });
            return Ok(new { message = "Dữ liệu đã được khởi tạo" });
        }
        /// <summary>
        /// Sửa thông tin user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public IActionResult Create(int id, CreateUserDto user)
        {
            var findUser = _user.FirstOrDefault(x => x.Id == id);  
            findUser.Name = user.Name;
            findUser.Email = user.Email;
            findUser.Password = user.Password;
            return Ok(new {message  =  "Dữ liệu đã được cập nhật"});
        }
        /// <summary>
        /// Hàm trả về danh sách user
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_user);
        }
        /// <summary>
        /// Hàm xóa user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("remove/{id}")]
        public IActionResult Remove(int id)
        {
            _user.Remove(_user.FirstOrDefault(user => user.Id == id)); 
            return Ok("Dữ liệu đã được xóa");
        }
    }
}
