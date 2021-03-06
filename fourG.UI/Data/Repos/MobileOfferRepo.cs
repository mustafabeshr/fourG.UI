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
    public class MobileOfferRepo
    {
        private readonly IAppDbContext _db;

        public MobileOfferRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<MobileOffer>> GetListAsync(string mobileNo, string offerId)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(mobileNo))
            {
                where = $" WHERE mobile_no = @MobileNo ";
                parameters.Add(new SqlParameter("MobileNo", mobileNo));
            }
            
            if (!string.IsNullOrEmpty(offerId))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE offer_id = @offerId " : $" AND offer_id = @offerId ";
                parameters.Add(new SqlParameter("offerId", offerId));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[mobile_offer] {where} ORDER BY row_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<MobileOffer>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = new AppConverter(_db).ToMobileOffer(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<MobileOffer> GetSingleAsync(int rowNo)
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
            var sql = $"SELECT * FROM [dbo].[mobile_offer] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = new AppConverter(_db).ToMobileOffer(row);
            return order;
        }
    }
}
