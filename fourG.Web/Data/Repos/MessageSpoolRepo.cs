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
    public class MessageSpoolRepo
    {
        private readonly IAppDbContext _db;

        public MessageSpoolRepo(IAppDbContext db)
        {
            this._db = db;
        }
        public async Task<List<MessageSpool>> GetListAsync(int id, string mobileNo, int status, int count = 100)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE row_id = @RowId ";
                parameters.Add(new SqlParameter("@RowId", id));
            }
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE mobile_no = @MobileNo " : $" AND mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("@MobileNo", mobileNo));
            }
            if (status >= 0)
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE status = @pStatus " : $" AND status = @pStatus ";
                parameters.Add(new SqlParameter("@pStatus", status));
            }
            #endregion
            var sql = $"SELECT TOP {count} * FROM[dbo].[message_spool] {where} ORDER BY row_id";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<MessageSpool>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToMessageSpool(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<MessageSpool> GetSingleAsync(int id)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE row_id = @RowId  ";
                parameters.Add(new SqlParameter("RowId", id));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[message_spool] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToMessageSpool(row);
            return order;
        }
        public async Task<int> Remove(int id) 
        {
            var parameters = new List<SqlParameter>();

            var idParameter = new SqlParameter();
            idParameter.ParameterName = "@p_rowNo";
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Direction = ParameterDirection.Input;
            idParameter.Value = id;
            parameters.Add(idParameter);

            var resultParameter = new SqlParameter();
            resultParameter.ParameterName = "@p_result";
            resultParameter.SqlDbType = SqlDbType.Int;
            resultParameter.Direction = ParameterDirection.Output;
            parameters.Add(resultParameter);

            await _db.ExecuteStoredProcAsync("sp_MessageSpool_Remove", parameters);

            return Convert.ToInt32(resultParameter.Value);

        } 
    }
}
