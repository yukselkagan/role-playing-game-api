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
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DbContext _context;
        public CharacterRepository(DbContext context)
        {
            this._context = context;
        }

        public Character CreateCharacter(Character character)
        {
            try
            {
                _context.Set<Character>().Add(character);
                _context.SaveChanges();
                return character;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }           

        }



        public Character Find(int characterId)
        {
            var character = _context.Set<Character>().FirstOrDefault(x => x.CharacterId == characterId);
            return character;
        }


        public Character Update(Character character)
        {
            _context.Set<Character>().Update(character);
            _context.SaveChanges();
            return character;
        }







    }
}
