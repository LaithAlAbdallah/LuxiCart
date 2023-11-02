using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.BL.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        
        IEnumerable<T> GetAll();
        void Add(T model);  
        void Update(T model);
        void EditById(int id);
        void Delete(int id);
        void SaveData();
        

        //async methods 
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        
    }
}
