using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class Repository : IRepository
    {
        private readonly PoiContext _context;

        public Repository(PoiContext context)
        {
            this._context = context;
        }

        public void Create(Poi poi)
        {
            _context.Pois.Add(poi);
            _context.SaveChanges();
        }

        public void Update(Poi poi)
        {
            _context.Update(poi);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var poi = _context.Set<Poi>().FirstOrDefault(p => p.Id == id);
            if (poi != null)
            {
                _context.Pois.Remove(poi);
                _context.SaveChanges();
            }
        }

        public Poi GetById(Guid id)
        {
            return _context.Set<Poi>().FirstOrDefault(p => p.Id == id);
        }

        public IReadOnlyList<Poi> GetAll()
        {
            return _context.Set<Poi>().ToList();
        }
        
    }
}
