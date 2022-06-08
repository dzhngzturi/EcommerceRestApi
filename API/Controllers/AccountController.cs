using AutoMapper;
using Ecommerce.Application.Contracts.Persistence.Services.Identity;
using Ecommerce.Application.DTOs.Account;
using Ecommerce.Application.Models.Identity;
using Ecommerce.Identity.Entity;
using Ecommerce.Identity.Extensions;
using Ecommerce.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(
            IUserService userService, UserManager<AppUser> userManager,
            IMapper mapper, ITokenService tokenService
            )
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _tokenService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _tokenService.Register(request));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<EmployeeDto>> Get()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            JwtSecurityToken jwt =  await _tokenService.GenerateToken(user);

            return new EmployeeDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                Email = user.Email,
                DisplayName = user.DisplayName,
            };

        }

        
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return Ok(await _userService.CheckEmailExistsAsync(email));
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult> GetUserAddress()
        {
            var user = await _userManager.FindByEmailWithAddressAsync(User);
            var data = _mapper.Map<AddressDto>(user.Address);
            return Ok(data);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult> UpdateUserAddress([FromQuery] AddressDto address)
        {

            var user = await _userManager.FindByEmailWithAddressAsync(User);
            user.Address = _mapper.Map<Address>(address);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(_mapper.Map<AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }


    } 
}
