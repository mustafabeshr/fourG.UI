using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.UI.Data.Interfaces
{
    public interface IAppDbContext
    {
        Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<SqlParameter> parameters);
        Task<DataTable> GetDataAsync(string sql, IEnumerable<SqlParameter> parameters);
        Task<int> ExecuteStoredProcAsync(string spName, IEnumerable<SqlParameter> parameters);
    }
}
