using DAL.EF;
using DAL.EF.TableClasses;
using DAL.TableClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.TableRepository
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly DALContext _context = new DALContext();

        public void Add(Character entity)
        {
            _context.Characters.Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Character> GetAll()
        {
            return _context.Characters;
        }

        public IEnumerable<Character> GetAllByAccount(Account acc)
        {
            Account c = _context.Accounts.SingleOrDefault(x => x.Username == acc.Username);
            return from b in _context.Characters
                   where b.AccountSerial == c.serial
                   select b;
        }

        public Character GetByIndex(int index)
        {
            return _context.Characters.Find(index);
        }

        public Character GetByName(string name)
        {
            return _context.Characters.Find(name);
        }

        public void Remove(Character entity)
        {
            _context.Characters.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Character entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /* //If for example you want all players from a certain faction, you could do this:
        public IEnumerable<Player> GetByFactionId(int id)
        {
            return _context.Players.Where(x => x.FactionId == id);
        }
        */
    }
}
