using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Exchange.WebServices.Auth.Validation;
using RolePlayingGame.Business.Abstract;
using RolePlayingGame.Entities.Base;
using RolePlayingGame.Entities.Dtos;
using RolePlayingGame.Entities.IBase;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RolePlayingGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        

        [HttpGet]
        [AllowAnonymous]
        public IResponse<List<PlayerDto>> GetAll()
        {

            var responsePlayerList = _service.GetAll();
            var response = new Response<List<PlayerDto>>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = responsePlayerList
            };
            return response;
        }



        [AllowAnonymous]
        [HttpGet("Test")]
        public string TokenTest()
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                // or
                //identity.FindFirst("ClaimName").Value;
                var newtest = claims;
                var new2 = claims.ToList();
                var new3 = new2[1];
                var new35 = new3.Value;
                var new4 = "hello";
                

            }

            


            return "hello world";
        }


        
        [HttpPost("Register")]
        [AllowAnonymous]
        public IResponse<PlayerToken> Register(PlayerRegisterDto playerRegister)
        {
            try
            {
                var responseToken = _service.Register(playerRegister);
                var response = new Response<PlayerToken>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = responseToken
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<PlayerToken>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }           
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponse<PlayerToken> Login(PlayerLoginDto playerLogin)
        {
            try
            {
                var responseToken = _service.Login(playerLogin);

                return new Response<PlayerToken>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = responseToken
                };
            }
            catch (Exception ex)
            {
                return new Response<PlayerToken>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }           
        }

        [HttpGet("GetPlayer")]
        public IResponse<PlayerDto> GetPlayer()
        {
            ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            int playerId = _service.ReadToken(claimsIdentity);
            Player player = _service.Find(playerId);

            PlayerDto playerDto = _mapper.Map<PlayerDto>(player);

            var response = new Response<PlayerDto>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = playerDto
            };

            return response;

        }

        [HttpPost("CreateCharacter")]
        [AllowAnonymous]
        public IResponse<CharacterDto> CreateCharacterForPlayer(CharacterCreateDto characterCreate)
        {
            try
            {
                ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                int playerId = _service.ReadToken(claimsIdentity);

                var responseCharacter = _service.CreateCharacterForPlayer(playerId, characterCreate);
                var mappedCharacterDto = _mapper.Map<CharacterDto>(responseCharacter);

                var response = new Response<CharacterDto>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = mappedCharacterDto
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<CharacterDto>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };

            }
            

        }




    }
}
