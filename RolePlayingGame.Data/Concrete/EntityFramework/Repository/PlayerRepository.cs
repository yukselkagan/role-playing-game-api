using Microsoft.Data.SqlClient;
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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DbContext _context;

        public PlayerRepository(DbContext context)
        {
            this._context = context;
        }

        public List<Player> GetAll()
        {   
            var playerList = _context.Set<Player>().ToList();
            return playerList;

        }

        public Player Find(int playerId)
        {
            var player = _context.Set<Player>().Include(x => x.Character).FirstOrDefault(x => x.PlayerId == playerId);
            return player;
        }

        public Player Register(Player playerRegister)
        {
            Player player = _context.Set<Player>().FirstOrDefault(x => x.Username == playerRegister.Username 
                || x.Email == playerRegister.Email );

            if(player is null)
            {
                _context.Set<Player>().Add(playerRegister);
                _context.SaveChanges();
                return playerRegister;
            }
            else
            {
                throw new Exception("Username or email already taken");
            }          
        }


        public Player Login(Player playerLogin)
        {
            var player = _context.Set<Player>().FirstOrDefault(x => x.Username == playerLogin.Username && x.Password == playerLogin.Password);
            return player;
        }

        public Player Update(Player player)
        {
            _context.Set<Player>().Update(player);
            _context.SaveChanges();
            return player;
        }


        



    }
}
