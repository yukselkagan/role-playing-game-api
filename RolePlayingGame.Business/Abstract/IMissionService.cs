using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Business.Abstract
{
    public interface IMissionService
    {

        public List<Mission> GetAll();
        public Mission Find(int missionId);
        public string DoMission(int playerId, int missionId);

    }
}
