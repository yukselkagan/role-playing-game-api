using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Data.Abstract
{
    public interface IPlayerRepository
    {

        public List<Player> GetAll();
        public Player Find(int playerId);
        public Player Register(Player playerRegister);
        public Player Login(Player playerLogin);
        public Player Update(Player player);

    }
}
