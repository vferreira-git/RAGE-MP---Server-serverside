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
    public class FactionRepository : IRepository<Faction>
    {
        private readonly DALContext _context = new DALContext();

        public void Add(Faction entity)
        {
            _context.Factions.Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Faction> GetAll()
        {
            return _context.Factions;
        }

        public Faction GetById(int id)
        {
            return _context.Factions.Find(id);
        }

        public Faction GetByUsername(string username)
        {
            return _context.Factions.Find(username);
        }

        public void Remove(Faction entity)
        {
            _context.Factions.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Faction entity)
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
