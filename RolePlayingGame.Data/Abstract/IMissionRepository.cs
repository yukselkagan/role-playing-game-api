using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Data.Abstract
{
    public interface IMissionRepository
    {
        public List<Mission> GetAll();
        public Mission Find(int missionId);
    }
}
