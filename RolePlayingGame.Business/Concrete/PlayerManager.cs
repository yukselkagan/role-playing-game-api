using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RolePlayingGame.Business.Abstract;
using RolePlayingGame.Business.Main;
using RolePlayingGame.Data.Abstract;
using RolePlayingGame.Entities.Base;
using RolePlayingGame.Entities.Dtos;
using RolePlayingGame.Entities.IBase;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Concrete
{
    public class PlayerManager : IPlayerService
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;
        IConfiguration configuration;
        private readonly ICharacterService _characterService;

        public PlayerManager(IPlayerRepository repository, IMapper mapper, IConfiguration configuration,
            ICharacterService characterService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this.configuration = configuration;
            this._characterService = characterService;
        }

        public List<PlayerDto> GetAll()
        {
            try
            {
                List<Player> list = _repository.GetAll();
                List<PlayerDto> mappedList = list.Select(x => _mapper.Map<PlayerDto>(x)).ToList();


                return mappedList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public Player Find(int playerId)
        {
            var player = _repository.Find(playerId);
            return player;
        }



        public PlayerToken Register(PlayerRegisterDto playerRegister)
        {
            try
            {
                Player mappedPlayer = _mapper.Map<Player>(playerRegister);
                var responsePlayer = _repository.Register(mappedPlayer);

                var token = new TokenManager(configuration).CreateAccessToken(responsePlayer);

                var playerToken = new PlayerToken()
                {
                    Player = mappedPlayer,
                    AccessToken = token
                };


                return playerToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public PlayerToken Login(PlayerLoginDto playerLogin)
        {
            var mappedPlayer = _mapper.Map<Player>(playerLogin);
            var responsePlayer = _repository.Login(mappedPlayer);

            if(responsePlayer != null)
            {
                var tokenString = new TokenManager(configuration).CreateAccessToken(responsePlayer);

                var playerToken = new PlayerToken
                {
                    Player = responsePlayer,
                    AccessToken = tokenString
                };

                return playerToken;

            }
            else
            {
                throw new Exception("Username or password is not correct");
            }
        }


        public int ReadToken(ClaimsIdentity claimsIdentity)
        {
            try
            {
                List<Claim> claims = claimsIdentity.Claims.ToList();
                Claim claimId = claims.FirstOrDefault(x => x.Type == "id");
                if(claimId is not null)
                {
                    int userId = Convert.ToInt32(claimId.Value);
                    return userId;
                }
                else
                {
                    throw new Exception("Can not find identity");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }



        public Character CreateCharacterForPlayer(int playerId, CharacterCreateDto characterCreate)
        {
            try
            {
                var mappedCharacter = _mapper.Map<Character>(characterCreate);
                Player player = Find(playerId);
                if(player.Character is null)
                {
                    //mappedCharacter.Player = player;
                    mappedCharacter.PlayerId = player.PlayerId;

                    var responseCharacter = _characterService.CreateCharacter(mappedCharacter);
                    player.CharacterId = responseCharacter.CharacterId;

                    _repository.Update(player);

                    return responseCharacter;
                }
                else
                {
                    throw new Exception("Player already have a character");
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }


        





    }
}
