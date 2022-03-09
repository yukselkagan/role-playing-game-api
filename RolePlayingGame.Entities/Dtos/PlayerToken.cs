using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Entities.Dtos
{
    public class PlayerToken
    {
        public Player Player { get; set; }
        public string AccessToken { get; set; }
    }
}
