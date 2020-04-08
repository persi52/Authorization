using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Modele;
using System.Linq;
using WebApplication1.Commands;
using WebApplication1.Services;
using WebApplication1.Requests;
using System.Threading.Tasks;
using WebApplication1.Responses;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
   

        public class IdentityController : Controller
        {
            private readonly IIdentityService _identityService;
           

        public IdentityController(IIdentityService identityService)
            {
                _identityService = identityService;
                
            }

            [HttpPost(ApiRoutes.Identity.Register)]
            public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
            {
               

                var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

                if(!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                   Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
            }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {


            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }

    }
    }  
