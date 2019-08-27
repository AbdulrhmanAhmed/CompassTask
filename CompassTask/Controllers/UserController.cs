using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompassTask.Data;
using CompassTask.DTOS;
using CompassTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompassTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, IMapper mapper, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            _logger.LogInformation("Get Users Actions");
            try
            {
                var users = await _userRepository.GetUsers();
                var ListUsers = _mapper.Map<IEnumerable<UserListDto>>(users);
                return Ok(ListUsers);
            }
            catch(Exception ex) {
                _logger.LogCritical("Exeption while get Users",ex);
                throw;
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUsers(UserAddDto userAddDto)
        {
            try { 
            if (userAddDto == null)
            {
                return BadRequest();
            }
            if (await _userRepository.EmailExist(userAddDto.Email))
            {
                ModelState.AddModelError("Email", "Email Already Exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(userAddDto);

            var users = await _userRepository.AddUser(user);
            return NoContent();
        }
            catch (Exception ex)
            {
                _logger.LogCritical("Exeption while Add Users", ex);
                throw;
            }
        }

        [Route("EditUser")]
        public async Task<ActionResult> EditUsers(UserEditDto userEditDto)
        {
            try { 
            if (userEditDto == null)
            {
                return BadRequest();
            }
            var user = await _userRepository.GetUser(userEditDto.Id);
            if (user == null)
            {
                return BadRequest("User Not Exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.Id = userEditDto.Id;
            user.Name = userEditDto.Name;
            user.Email = userEditDto.Email;
            user.IsActive = userEditDto.IsActive;

            var users = await _userRepository.EditUser(user);
            return NoContent();
        }
            catch (Exception ex)
            {
                _logger.LogCritical("Exeption while Edit Users", ex);
                throw;
            }
        }


   
    }
}
