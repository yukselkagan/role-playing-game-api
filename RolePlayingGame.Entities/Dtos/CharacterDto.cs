using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Entities.Dtos
{
    public class CharacterDto
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }
        public int CharacterLevel { get; set; }
        public int Experience { get; set; }
        public int MaxExperience { get; set; }
    }
}
