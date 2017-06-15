using MvvmCross.Platform;
using MvvmCross.Plugins.Sqlite;
using System.Collections.Generic;
using MvxForms.Core.Model;

namespace MvxForms.Core.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel, new()
    {
        private static string DbName = "Database.sqlite";

        private readonly IMvxSqliteConnectionFactory _connectionFactory;

        public BaseRepository(IMvxSqliteConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            
            using (var conn = _connectionFactory.GetConnection(DbName))
            {
                conn.CreateTable<T>();
            }
        }

        public T GetById(string id)
        {
            using (var conn = _connectionFactory.GetConnection(DbName))
            {
                return conn.Get<T>(id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var conn = _connectionFactory.GetConnection(DbName))
            {
                return conn.Table<T>();
            }
        }

        public int Insert(T item)
        {
            using (var conn = _connectionFactory.GetConnection(DbName))
            {
                return conn.Insert(item,typeof(T));
            }
        }

        public int Update(T item)
        {

            using (var conn = _connectionFactory.GetConnection(DbName))
            {
                return conn.Update(item,typeof(T));
            }
        }

        public int Delete(T item)
        {
            using (var conn = _connectionFactory.GetConnection(DbName))
            {
                return conn.Delete<T>(item.ID);
            }
        }
    }
}
