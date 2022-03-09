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
    public class MissionManager : IMissionService
    {
        private readonly IMissionRepository _repository;
        private readonly ICharacterService _characterService;
        private readonly IPlayerService _playerService;
        public MissionManager(IMissionRepository repository, ICharacterService characterService, 
            IPlayerService playerService)
        {
            _repository = repository;
            _characterService = characterService;
            _playerService = playerService;
        }

        public List<Mission> GetAll()
        {
            var missionList = _repository.GetAll();
            return missionList;
        }


        public Mission Find(int missionId)
        {
            var responseMission = _repository.Find(missionId);
            if(responseMission is not null)
            {
                return responseMission;
            }
            else
            {
                throw new Exception("Can not find mission");
            }
        }


        public string DoMission(int playerId, int missionId)
        {
            var targetPlayer = _playerService.Find(playerId);
            var targetCharacter = _characterService.Find(targetPlayer.Character.CharacterId);

            var targetMission = Find(missionId);


            if(targetCharacter.CharacterLevel >= targetMission.RequiredLevel)
            {
                Random rnd = new Random();
                var randomTakenDamage = rnd.Next(targetMission.MinimumDamage, targetMission.MaximumDamage + 1);

                if(targetCharacter.Health > randomTakenDamage)
                {
                    string response = $"Mission successfull, {targetMission.GivenExperience} experience gained " +
                        $" {randomTakenDamage} damage taken";

                    return response;




                }
                else
                {
                    return $"{randomTakenDamage} damage taken, you died";
                }


                
                //targetCharacter.CharacterLevel += 1;
                //var responseCharacter = _characterService.Update(targetCharacter);


            }
            else
            {
                return "Character level is not enough";
            }


            


            return "problem";


        }




    }
}
