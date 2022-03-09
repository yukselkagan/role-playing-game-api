using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolePlayingGame.Business.Abstract;
using RolePlayingGame.Entities.Base;
using RolePlayingGame.Entities.Dtos;
using RolePlayingGame.Entities.IBase;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RolePlayingGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _service;
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;
        private readonly IPlayerService _playerService;
        public MissionController(IMissionService service, IMapper mapper, ICharacterService characterService,
            IPlayerService playerService)
        {
            _service = service;
            _mapper = mapper;
            _characterService = characterService;
            _playerService = playerService;
        }


        [HttpGet("GetAll")]
        [AllowAnonymous]
        public Response<List<MissionDto>> GetAll()
        {
            var missionList = _service.GetAll();
            var mappedMissionList = missionList.Select(x => _mapper.Map<MissionDto>(x)).ToList();

            var response = new Response<List<MissionDto>>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = mappedMissionList
            };
            return response;

        }


        [HttpPost("DoMission/{missionId}")]
        [AllowAnonymous]
        public IResponse<string> DoMission(int missionId)
        {
            ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            //int playerId = _playerService.ReadToken(claimsIdentity);
            int playerId = 1002;

            var responseString = _service.DoMission(playerId, missionId);


            var response = new Response<string>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = responseString
            };

            return response;


        }



    }
}
