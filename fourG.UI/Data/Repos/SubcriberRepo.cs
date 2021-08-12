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
    public class SubscriberRepo
    {
        private readonly IAppDbContext _db;

        public SubscriberRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<Subscriber>> GetListAsync(string imsi, string mobileNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where = $" WHERE mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            if (string.IsNullOrEmpty(imsi))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE imsi = @IMSI " : $" AND imsi = @IMSI ";
                parameters.Add(new SqlParameter("IMSI", imsi));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[Subscribers] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<Subscriber>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToSubscriber(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<Subscriber> GetSingleAsync(int rowNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (rowNo > 0)
            {
                where = $" WHERE row_no = @RowNo ";
                parameters.Add(new SqlParameter("RowNo", rowNo));
            }
            else
            {
                return null;
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[Subscribers] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToSubscriber(row);
            return order;
        }
        public async Task<Subscriber> GetSingleByMobileAsync(string mobileNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where = $" WHERE mobile_no = @RowNo ";
                parameters.Add(new SqlParameter("RowNo", mobileNo));
            }
            else
            {
                return null;
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[Subscribers] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToSubscriber(row);
            return order;
        }
    }
}
