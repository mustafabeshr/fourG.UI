using System.Data.SqlClient;
using fourG.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace fourG.Infra
{
    public class AppDbContext : IAppDbContext
    {
        public IConfiguration Configuration { get; }
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private SqlConnection GetConnection(string connectionStringName)
        {
            var connString = Configuration.GetConnectionString(connectionStringName);
            return new SqlConnection(connString);
        }
        public async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<SqlParameter> parameters)
        {
            using (var conn = GetConnection("AppDb"))
            {
                var cmd = GetCommand(sql, parameters);
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> ExecuteStoredProcAsync(string spName, IEnumerable<SqlParameter> parameters)
        {
            using (var conn = GetConnection("AppDb"))
            {
                var cmd = GetCommand(spName, parameters);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open) conn.Open();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<DataTable> GetDataAsync(string sql, IEnumerable<SqlParameter> parameters)
        {
            using (var conn = GetConnection("AppDb"))
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

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                return ds.Tables[0];
            }
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
