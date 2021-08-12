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
    public class ProductRepo
    {
        private readonly IAppDbContext _db;

        public ProductRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public async Task<List<Product>> GetListAsync(int id, string firstId, string secondId)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE product_no = @ProductNo " ;
                parameters.Add(new SqlParameter("ProductNo", id));
            }
            if (!string.IsNullOrEmpty(firstId))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE product_id1 = @firstId " : $" AND product_id1 = @firstId ";
                parameters.Add(new SqlParameter("firstId", firstId));
            }
            if (!string.IsNullOrEmpty(secondId))
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE product_id2 = @secondId " : $" AND product_id2 = @secondId ";
                parameters.Add(new SqlParameter("secondId", secondId));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[products] {where} ORDER BY product_no";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;

            var result = new List<Product>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = AppConverter.ToProduct(row);
                result.Add(order);
            }
            return result;
        }

        public async Task<Product> GetSingleAsync(int id)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (id > 0)
            {
                where = $" WHERE product_no = @ProductNo  ";
                parameters.Add(new SqlParameter("ProductNo", id));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[products] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = AppConverter.ToProduct(row);
            return order;
        }
    }
}
