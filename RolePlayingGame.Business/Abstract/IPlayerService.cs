using RolePlayingGame.Entities.Dtos;
using RolePlayingGame.Entities.IBase;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Abstract
{
    public interface IPlayerService
    {

        public List<PlayerDto> GetAll();
        public Player Find(int playerId);
        public PlayerToken Register(PlayerRegisterDto playerRegister);
        public PlayerToken Login(PlayerLoginDto playerLogin);
        public int ReadToken(ClaimsIdentity claimsIdentity);

        public Character CreateCharacterForPlayer(int playerId, CharacterCreateDto characterCreate);



    }
}
