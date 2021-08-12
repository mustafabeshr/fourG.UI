using fourG.UI;
using fourG.UI.Data.Entities;
using fourG.UI.Data.Interfaces;
using fourG.UI.Data.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace fourG.UI.Data.Repo
{
    public class SubscriberExceedMaxValidityRepo
    {
        private readonly IAppDbContext _db;

        public SubscriberExceedMaxValidityRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<SubscriberExceedMaxValidity>> GetListAsync(string packageId, string mobileNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(packageId))
            {
                where = $" WHERE pkg_id = @packageId " ;
                parameters.Add(new SqlParameter("packageId", packageId));
            }
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE mobile_no = @mobileNo " : $" AND mobile_no = @mobileNo ";
                parameters.Add(new SqlParameter("mobileNo", mobileNo));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[subs_exceed_max_validity] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<SubscriberExceedMaxValidity>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToSubscriberExceedMaxValidity(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<SubscriberExceedMaxValidity> GetSingleAsync(int id)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE row_no = @RowNo  ";
                parameters.Add(new SqlParameter("RowNo", id));
            }
            else
            {
                return null;
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[subs_exceed_max_validity] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToSubscriberExceedMaxValidity(row);
            return order;
        }
    }
}
