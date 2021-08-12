using fourG.Data;
using fourG.Infra.Interfaces;
using fourG.Infra.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Infra
{
    public class LteOrderRepo
    {
        private readonly IAppDbContext _db;

        public LteOrderRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<LteOrder>> GetListAsync(string mobileNo, string imsi, string offerId, int status)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where = $" WHERE mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            if (!string.IsNullOrEmpty(imsi))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE imsi = @imsi " : $" AND imsi = @imsi ";
                parameters.Add(new SqlParameter("imsi", imsi));
            }
            if (!string.IsNullOrEmpty(offerId))
            {
                where += string.IsNullOrEmpty(where) ?  $" WHERE offer_id = @offerId " : $" AND offer_id = @offerId ";
                parameters.Add(new SqlParameter("offerId", offerId));
            }
            if (status >= 0)
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE status = @status " : $" AND status = @status ";
                parameters.Add(new SqlParameter("status", offerId));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[LTE_ORDERS] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<LteOrder>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = AppConverter.ToLteOrder(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<LteOrder> GetSingleAsync(int rowNo)
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
            var sql = $"SELECT * FROM [dbo].[LTE_ORDERS] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            DataRow row = resultData.Rows[0];
            var order = AppConverter.ToLteOrder(row);
            return order;
        }

        public async Task<List<LteOrderHistory>> GetListHistoryAsync(string mobileNo, string imsi, string offerId, int status)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where = $" WHERE mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            if (!string.IsNullOrEmpty(imsi))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE imsi = @imsi " : $" AND imsi = @imsi ";
                parameters.Add(new SqlParameter("imsi", imsi));
            }
            if (!string.IsNullOrEmpty(offerId))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE offer_id = @offerId " : $" AND offer_id = @offerId ";
                parameters.Add(new SqlParameter("offerId", offerId));
            }
            if (status >= 0)
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE status = @status " : $" AND status = @status ";
                parameters.Add(new SqlParameter("status", offerId));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[LTE_ORDERS_HIS] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<LteOrderHistory>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = AppConverter.ToLteOrderHistory(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<LteOrderHistory> GetSingleHistoryAsync(int rowNo)
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
            var sql = $"SELECT * FROM [dbo].[LTE_ORDERS_HIS] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            DataRow row = resultData.Rows[0];
            var order = AppConverter.ToLteOrderHistory(row);
            return order;
        }

    }
}
