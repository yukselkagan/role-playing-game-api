using RolePlayingGame.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Entities.Dtos
{
    public class PlayerDto : DtoBase
    {
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
