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
    public class SMSReceiverRepo
    {
        private readonly IAppDbContext _db;

        public SMSReceiverRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<int> Create(SMSReceiver obj)
        {
            var parameters = new List<SqlParameter>();

            var mobileNoParameter = new SqlParameter();
            mobileNoParameter.ParameterName = "@p_mobile_no";
            mobileNoParameter.SqlDbType = SqlDbType.VarChar;
            mobileNoParameter.Direction = ParameterDirection.Input;
            mobileNoParameter.Size = 50;
            mobileNoParameter.Value = obj.MobileNo;
            parameters.Add(mobileNoParameter);

            var messageParameter = new SqlParameter();
            messageParameter.ParameterName = "@p_message";
            messageParameter.SqlDbType = SqlDbType.NVarChar;
            messageParameter.Direction = ParameterDirection.Input;
            messageParameter.Size = 300;
            messageParameter.Value = obj.Message;
            parameters.Add(messageParameter);

            var shortcodeParameter = new SqlParameter();
            shortcodeParameter.ParameterName = "@p_shortcode";
            shortcodeParameter.SqlDbType = SqlDbType.VarChar;
            shortcodeParameter.Direction = ParameterDirection.Input;
            shortcodeParameter.Size = 50;
            shortcodeParameter.Value = obj.Shortcode;
            parameters.Add(shortcodeParameter);

            var resultParameter = new SqlParameter();
            resultParameter.ParameterName = "@p_result";
            resultParameter.SqlDbType = SqlDbType.Int;
            resultParameter.Direction = ParameterDirection.Output;
            parameters.Add(resultParameter);


            await _db.ExecuteStoredProcAsync("sp_smsReceiver_create", parameters);

            return Convert.ToInt32(resultParameter.Value);

        }
        public async Task<List<SMSReceiver>> GetListAsync(int id, string mobileNo)
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
            var sql = $"SELECT * FROM [dbo].[sms_receiver] {where} ORDER BY row_id";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<SMSReceiver>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToSMSReceiver(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<SMSReceiver> GetSingleAsync(int id)
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
            var sql = $"SELECT * FROM [dbo].[sms_receiver] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToSMSReceiver(row);
            return order;
        }
    }
}
