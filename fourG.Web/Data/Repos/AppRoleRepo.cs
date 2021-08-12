using fourG.Web;
using fourG.Web.Data.Entities;
using fourG.Web.Data.Interfaces;
using fourG.Web.Data.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Repo
{
    public class AppRoleRepo
    {
        private readonly IAppDbContext _db;

        public AppRoleRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<AppRole>> GetListAsync()
        {
            var sql = $"SELECT  * FROM[dbo].[roles] ORDER BY role_id";
            var resultData = await _db.GetDataAsync(sql, null);
            if (resultData == null) return null;

            var result = new List<AppRole>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToAppRole(row);
                result.Add(order);
            }
            return result;
        }
        public async Task<AppRole> GetSingleAsync(int id)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE role_id = @RowId  ";
                parameters.Add(new SqlParameter("RowId", id));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[roles] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToAppRole(row);
            return order;
        }
    }
}
