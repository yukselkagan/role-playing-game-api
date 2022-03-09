using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Abstract
{
    public interface ICharacterService
    {


        public Character CreateCharacter(Character character);
        public Character Find(int characterId);
        public Character Update(Character character);

    }
}
