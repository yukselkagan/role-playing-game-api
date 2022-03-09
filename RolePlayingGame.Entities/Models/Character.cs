using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Entities.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }
        public int CharacterLevel { get; set; }
        public int Experience { get; set; }
        public int MaxExperience { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }

    }
}
