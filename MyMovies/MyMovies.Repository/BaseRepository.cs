using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected MyMoviesDbContext _context { get; set; }
        public BaseRepository(MyMoviesDbContext context)
        {
            _context = context;
        }
        
        
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        
        
        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public virtual T GetById(int entityId)
        {
            return _context.Set<T>().Find(entityId);
        }
    }
}
