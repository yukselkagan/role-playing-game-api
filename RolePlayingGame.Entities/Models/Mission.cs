using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Entities.Models
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public int RequiredLevel { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int GivenExperience { get; set; }


    }
}
