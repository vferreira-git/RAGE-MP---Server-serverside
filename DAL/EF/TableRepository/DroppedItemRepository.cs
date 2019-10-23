using DAL.EF.TableClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.EF.TableRepository
{
    public class DroppedItemRepository : IRepository<DroppedItem>
    {
        private readonly DALContext _context = new DALContext();
        public void Add(DroppedItem entity)
        {
            _context.DroppedItems.Add(entity);
            _context.SaveChanges();
        }
        public List<DroppedItem> GetAllList()
        {
            return _context.DroppedItems.ToList();
        }

        public IEnumerable<DroppedItem> GetAll()
        {
            return _context.DroppedItems.ToList();
        }

        public DroppedItem GetByIndex(int index)
        {
            return _context.DroppedItems.Find(index);
        }

        public DroppedItem GetByName(string name)
        {
            return _context.DroppedItems.Find(name);
        }

        public void Remove(DroppedItem entity)
        {
            _context.DroppedItems.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(DroppedItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
