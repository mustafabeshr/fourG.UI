using System.Data.SqlClient;
using fourG.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Data
{
    public class AppDbContext : IAppDbContext
    {
        public async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<SqlParameter> parameters, string connectionString)
        {
            using (var conn = GetConnection(connectionString))
            {
                var cmd = GetCommand(sql, parameters);
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> ExecuteStoredProcAsync(string spName, IEnumerable<SqlParameter> parameters, string connectionString)
        {
            using (var conn = GetConnection(connectionString))
            {
                var cmd = GetCommand(spName, parameters);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<DataTable> GetDataAsync(string sql, IEnumerable<SqlParameter> parameters, string connectionString)
        {
            using (var conn = GetConnection(connectionString))
            {
                var ds = new DataSet();
                await Task.Run(() =>
                {
                    var cmd = GetCommand(sql, parameters);
                    cmd.Connection = conn;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                });
                return ds.Tables[0];
            }
        }
        private SqlConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        private SqlCommand GetCommand(string sql, IEnumerable<SqlParameter> parameters)
        {
            var cmd = new SqlCommand(sql);
            if (parameters != null && parameters.Count() > 0)
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }
    }
}
