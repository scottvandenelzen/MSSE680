//*********************************************************************************//
//***********************Generic Repository Pattern********************************//
//*********************************************************************************//




using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Configuration;
namespace DAL
{
    /// <summary>
    /// This is the Data Repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
//    public class DataRepository<T> : IDataRepository<T>, IDataRepository where T : class
    public class DataRepository<T> : IDataRepository where T : class
    {
        /// <summary>
        /// Data Context object to interact with the db
        /// </summary>
        readonly DbContext _dataContext;

        /// <summary>
        /// Public constructor
        /// </summary>
        public DataRepository()
        {
            //instantiate the datacontext by reading the connection string
            _dataContext = new DbContext(ConfigurationManager.ConnectionStrings["scottEntities"].ConnectionString);

        }
        /// <summary>
        /// Dispose method for the class
        /// </summary>
        public void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }

        /// <summary>
        /// This method is used to return a collection of objects
        /// by specific key i.e a column name and the
        /// specific value associated with the column
        /// </summary>
        /// <param name="KeyName">The name of the key</param>
        /// <param name="KeyVal">The integer value of the column</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetBySpecificKey(string KeyName, int KeyVal)
        {

            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                       KeyName
                        ),
                    Expression.Constant(KeyVal)
                    ),
                new[] { itemParameter }
                );
            try
            {
                return GetAll().Where(whereExpression).AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// This method is used to return a collection of objects
        /// by specific key i.e a column name and the
        /// specific value associated with the column
        /// </summary>
        /// <param name="KeyName">The name of the key</param>
        /// <param name="KeyVal">The integer value of the column</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetBySpecificKey(string KeyName, int? KeyVal)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                       KeyName
                        ),
                    Expression.Constant(KeyVal)
                    ),
                new[] { itemParameter }
                );
            try
            {
                return GetAll().Where(whereExpression).AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// This method is used to return a collection of objects
        /// by specific key i.e a column name and the
        /// specific value associated with the column
        /// </summary>
        /// <param name="KeyName">The name of the key</param>
        /// <param name="KeyVal">The string value of the column</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetBySpecificKey(string KeyName, string KeyVal)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                       KeyName
                        ),
                    Expression.Constant(KeyVal)
                    ),
                new[] { itemParameter }
                );
            try
            {
                return GetAll().Where(whereExpression).AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns all the records from a table
        /// </summary>
        /// <returns>Collection of records</returns>
        public virtual IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Inserts a record into the database
        /// </summary>
        /// <param name="entity">The entity to be inserted</param>
        public virtual void Insert(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();

        }

        /// <summary>
        /// Deletes a record from the table
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        public virtual void Delete(T entity)
        {
            var entry = _dataContext.Entry(entity);
            if (entry != null)
            {
                entry.State = System.Data.EntityState.Deleted;
            }
            else
            {
                _dataContext.Set<T>().Attach(entity);
            }
            _dataContext.Entry(entity).State = System.Data.EntityState.Deleted;
            _dataContext.SaveChanges();

        }
        /// <summary>
        /// Updates a record into a table
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            _dataContext.Set<T>().Attach(entity);
            _dataContext.Entry(entity).State = System.Data.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        IQueryable IDataRepository.GetAll()
        {
            return GetAll();
        }
        void IDataRepository.Insert(object entity)
        {
            Insert((T)entity);
        }
        void IDataRepository.Update(object entity)
        {
            Update((T)entity);
        }
        void IDataRepository.Delete(object entity)
        {
            Delete((T)entity);
        }

        IQueryable IDataRepository.GetBySpecificKey(string KeyName, string KeyVal)
        {
            return GetBySpecificKey(KeyName, KeyVal);
        }

        IQueryable IDataRepository.GetBySpecificKey(string KeyName, int KeyVal)
        {
            return GetBySpecificKey(KeyName, KeyVal);
        }
    }

    
    /// <summary>
    /// Generic interface
    /// </summary>
    public interface IDataRepository
    {
        IQueryable GetAll();
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
        IQueryable GetBySpecificKey(string KeyName, string KeyVal);
        IQueryable GetBySpecificKey(string KeyName, int KeyVal);
    }
}
//*********************************************************************************//
//*************************************END*****************************************//
//*********************************************************************************//