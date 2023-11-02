using LuxiCart.BL.IRepositories;
using LuxiCart.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext _db;
        public BaseRepository( AppDbContext db)
        {
            _db = db;
        }
        public void Add(T model)
        {
            _db.Set<T>().Add(model);
            SaveData();
        }

        

        public void Delete(int id)
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
            }
            SaveData();
        }

        public void EditById(int id)
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null) 
            {
                _db.Set<T>().Update(entity);
            }
            SaveData();
        }

        public IEnumerable<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _db.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id)!;

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

		

		public void SaveData()
        {
            _db.SaveChanges();
        }

        public void Update(T model)
        {
            _db.Set<T>().Update(model);
            SaveData();
        }
    }
}
