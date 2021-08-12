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
    public class OperationLogRepo
    {
        private readonly IAppDbContext _db;

        public OperationLogRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<OperationLog>> GetListAsync(int transId, string mobileNo)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where = $" WHERE mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            if (transId > 0)
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE trans_no = @TransNO " : $" AND trans_no = @TransNO ";
                parameters.Add(new SqlParameter("TransNO", transId));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[operation_log] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<OperationLog>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToOperationLog(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<OperationLog> GetSingleAsync(int rowNo)
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
            var sql = $"SELECT * FROM [dbo].[operation_log] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToOperationLog(row);
            return order;
        }
    }
}
