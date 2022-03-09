using Microsoft.EntityFrameworkCore;
using RolePlayingGame.Data.Abstract;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Data.Concrete.EntityFramework.Repository
{
    public class MissionRepository : IMissionRepository
    {
        private readonly DbContext _context;
        public MissionRepository(DbContext context)
        {
            _context = context;
        }

        public List<Mission> GetAll()
        {
            var missionList = _context.Set<Mission>().ToList();
            return missionList;
        }

        public Mission Find(int missionId)
        {
            var mission = _context.Set<Mission>().FirstOrDefault(x => x.MissionId == missionId);
            return mission;
        }



    }
}
