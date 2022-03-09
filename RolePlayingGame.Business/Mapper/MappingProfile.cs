using AutoMapper;
using RolePlayingGame.Entities.Dtos;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Player, PlayerRegisterDto>().ReverseMap();
            CreateMap<Player, PlayerLoginDto>().ReverseMap();

            CreateMap<Character, CharacterDto>().ReverseMap();
            CreateMap<Character, CharacterCreateDto>().ReverseMap();

            CreateMap<Mission, MissionDto>().ReverseMap();

        }
    }
}
