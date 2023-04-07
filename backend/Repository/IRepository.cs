using System.Collections.Generic;
using System.Web.Http;
using WADAPI.Models;

namespace WADAPI.Repository
{
        public interface IRepository<T>
        {
            // Retrieve all
            /// <summary>
            /// Method returns all entity types items
            /// </summary>
            /// <returns>T</returns>
            IEnumerable<T> GetAll();
            // Retreive one by ID
            /// <summary>
            /// Returns T object that is retrieved from database using passed id variable 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>T</returns>
            T GetById(int id);
            // Create New
            /// <summary>
            /// Method is used to create new entity in database
            /// </summary>
            /// <param name="entity"></param>
            void Add(T entity);
            void Update(T entity);
            // Delete Order by ID
            /// <summary>
            /// Method to delete recipe using passed id variable
            /// </summary>
            /// <param name="id"></param>
            void Delete(int id);
            // Delete Order by ID
            /// <summary>
            /// Function to retrieve recipes that belongs to one user
            /// </summary>
            /// <param name="userId"></param>
            IEnumerable<T> GetByUserId(int userId);

        }
}
