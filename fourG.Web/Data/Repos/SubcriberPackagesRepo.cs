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
    public class SubcriberPackagesRepo
    {
        private readonly IAppDbContext _db;

        public SubcriberPackagesRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<SubscriberPackage>> GetListAsync(string imsi, string mobileNo)
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
            var sql = $"SELECT * FROM [dbo].[subscriber_bkgs] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<SubscriberPackage>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToSubscriberPackage(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<SubscriberPackage> GetSingleAsync(int rowNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (rowNo > 0)
            {
                where = $" WHERE row_no = @RowNo ";
                parameters.Add(new SqlParameter("RowNo", rowNo));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[subscriber_bkgs] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToSubscriberPackage(row);
            return order;
        }

        public async Task<List<SubscriberPackageHistory>> GetListHistoryAsync(string imsi, string mobileNo)
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
            var sql = $"SELECT * FROM [dbo].[subscriber_bkgs_his] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<SubscriberPackageHistory>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToSubscriberPackageHistory(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<SubscriberPackageHistory> GetSingleHistoryAsync(int rowNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (rowNo > 0)
            {
                where = $" WHERE row_no = @RowNo ";
                parameters.Add(new SqlParameter("RowNo", rowNo));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[subscriber_bkgs_his] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToSubscriberPackageHistory(row);
            return order;
        }
    }
}
