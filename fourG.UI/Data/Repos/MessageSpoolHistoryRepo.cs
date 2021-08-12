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
    public class MessageSpoolHistoryRepo
    {
        private readonly IAppDbContext _db;

        public MessageSpoolHistoryRepo(IAppDbContext db)
        {
            this._db = db;
        }
        public async Task<List<MessageSpoolHistory>> GetListAsync(int id, string mobileNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE row_id = @RowId ";
                parameters.Add(new SqlParameter("RowId", id));
            }
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE mobile_no = @MobileNo " : $" AND mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            #endregion
            var sql = $"SELECT * FROM[dbo].[message_spool_bak] {where} ORDER BY row_id";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<MessageSpoolHistory>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToMessageSpoolHistory(row);
                result.Add(order);
            }
            return result;
        }


        public async Task<List<MessageSpoolHistory>> GetAllListAsync(string message, string mobileNo, int count = 1000)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(message))
            {
                where = $" WHERE (message LIKE '%' +  @Msg + '%') ";
                parameters.Add(new SqlParameter("Msg", message));
            }
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE mobile_no = @MobileNo " : $" AND mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            #endregion
            var sql = $"SELECT TOP({count}) * FROM[dbo].[v_message_spool_all] {where} ORDER BY createdon DESC";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<MessageSpoolHistory>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToMessageSpoolHistory(row);
                result.Add(order);
            }
            return result;
        }
        public async Task<MessageSpoolHistory> GetSingleAsync(int id)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE row_id = @RowId  ";
                parameters.Add(new SqlParameter("RowId", id));
            }
            else
            {
                return null;
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[message_spool_bak] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToMessageSpoolHistory(row);
            return order;
        }
    }
}
