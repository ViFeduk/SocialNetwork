using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SocialNetwork.DAL.Repositories
{
   abstract public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection(@"Data Source = D:\VisualStudio\Repos\SocialNetwork\SocialNetwork\DAL\DB\social_network_bd.db; Version = 3");
        }
        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }
        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                return connection.Execute(sql, parameters);
            }
        }
    }
}
