using DAL.EF;
using DAL.TableClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.TableRepository
{
    public class PlayerRepository : IRepository<Account>
    {
        private readonly DALContext _context = new DALContext();

        public void Add(Account entity)
        {
            _context.Accounts.Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts;
        }

        public Account GetById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public Account GetByUsername(string username)
        {
            return _context.Accounts.Find(username);
        }

        public Account GetBySerial(string serial)
        {
            return _context.Accounts.SingleOrDefault(x => x.serial == serial) ?? null;
        }

        public void Remove(Account entity)
        {
            _context.Accounts.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Account entity)
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
