using RolePlayingGame.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Entities.Models
{
    public class Player : EntityBase
    {
        public int PlayerId { get; set; }
        public string Username { get; set; }      
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
