using AutoMapper;
using RolePlayingGame.Business.Abstract;
using RolePlayingGame.Data.Abstract;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Concrete
{
    public class CharacterManager : ICharacterService
    {
        private readonly ICharacterRepository _repository;
        private readonly IMapper _mapper;
        public CharacterManager(ICharacterRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }




        public Character CreateCharacter(Character character)
        {
            try
            {
                var responseCharacter = _repository.CreateCharacter(character);
                return responseCharacter;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        public Character Find(int characterId)
        {
            var responseCharacter = _repository.Find(characterId);
            if(responseCharacter is not null)
            {
                return responseCharacter;
            }
            else
            {
                throw new Exception("Can not find character");
            }
            
        }


        public Character Update(Character character)
        {
            var responseCharacter = _repository.Update(character);
            return responseCharacter;
        }






    }
}
