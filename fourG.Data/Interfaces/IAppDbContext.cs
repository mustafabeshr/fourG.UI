using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Data.Interfaces
{
    public interface IAppDbContext
    {
        Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<SqlParameter> parameters, string connectionString);
        Task<DataTable> GetDataAsync(string sql, IEnumerable<SqlParameter> parameters, string connectionString);
        Task<int> ExecuteStoredProcAsync(string spName, IEnumerable<SqlParameter> parameters, string connectionString);
    }
}
