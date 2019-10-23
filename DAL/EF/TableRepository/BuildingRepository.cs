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
    public class BuildingRepository : IRepository<Building>
    {
        private readonly DALContext _context = new DALContext();

        public void Add(Building entity)
        {
            _context.Buildings.Add(entity);
            _context.SaveChanges();
        }
        public List<Building> GetAllList()
        {
            return _context.Buildings.ToList();
        }

        public IEnumerable<Building> GetAll()
        {
            return _context.Buildings.ToList();
        }

        public Building GetByIndex(int index)
        {
            return _context.Buildings.Find(index);
        }

        public Building GetByName(string name)
        {
            return _context.Buildings.Find(name);
        }

        public void Remove(Building entity)
        {
            _context.Buildings.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Building entity)
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
