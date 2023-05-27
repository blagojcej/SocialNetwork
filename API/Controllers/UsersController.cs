using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // var users = await _userRepository.GetUsersAsync();
            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            var usersToReturn = await _userRepository.GetMembersAsync();
            return Ok(usersToReturn);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            // var user = await _userRepository.GetUserByIdAsync(id);

            // if (user == null)
            // {
            //     return NotFound();
            // }

            // var userToReturn = _mapper.Map<MemberDto>(user);

            var userToReturn = await _userRepository.GetMemberByIdAsync(id);

            return Ok(userToReturn);
        }

        [HttpGet("getbyusername/{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
        {
            // var user = await _userRepository.GetUserByUsernameAsync(username);

            // if (user == null)
            // {
            //     return NotFound();
            // }

            // var userToReturn = _mapper.Map<MemberDto>(user);

            var userToReturn = await _userRepository.GetMemberByUsernameAsync(username);

            return Ok(userToReturn);
        }
    }
}