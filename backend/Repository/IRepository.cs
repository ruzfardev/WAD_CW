using System.Collections.Generic;
using WADAPI.Models;

namespace WADAPI.Repository
{
        public interface IRepository<T>
        {
            IEnumerable<T> GetAll();
            T GetById(int id);
            void Add(T entity);
            void Update(T entity, int id);
            void Delete(int id);

        }
}
