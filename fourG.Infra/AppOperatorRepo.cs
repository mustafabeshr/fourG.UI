using fourG.Data;
using fourG.Infra.Interfaces;
using fourG.Infra.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Infra
{
    public class AppOperatorRepo : IAppOperator
    {
        private readonly IAppDbContext _db;

        public AppOperatorRepo(IAppDbContext db)
        {
            this._db = db;
        }

        public string GetLoggedOperatorId(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return "-1";

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
                return "-1";

            string currectOperatorId = claim.Value;

            //if (!int.TryParse(claim.Value, out currentUserId))
            //    return "-1";

            return currectOperatorId;
        }
        public int GetLoggedOperatorRoleId(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return -1;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            if (claim == null)
                return -1;

            int currentRoleId = int.Parse(claim.Value);

            //if (!int.TryParse(claim.Value, out currentUserId))
            //    return "-1";

            return currentRoleId;
        }
        public async Task<List<AppOperator>> GetListAsync(int status, int role)
        {

            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (status >= 0)
            {
                where = $" WHERE status = @OpStatus ";
                parameters.Add(new SqlParameter("@OpStatus", status));
            }
            if (role >= 0)
            {
                where += string.IsNullOrEmpty(where) ? $" WHERE op_role_id = @RoleId " : $" AND op_role_id = @RoleId ";
                parameters.Add(new SqlParameter("@RoleId", role));
            }
            
            #endregion
            var sql = $"SELECT  * FROM[dbo].[operators]  {where}  ORDER BY op_id";
            var resultData = await _db.GetDataAsync(sql, null);
            if (resultData == null) return null;

            var result = new List<AppOperator>();
            foreach (DataRow row in resultData.Rows)
            {
                var order = AppConverter.ToAppOperator(row);
                result.Add(order);
            }
            return result;
        }
        public async Task<AppOperator> GetSingleAsync(string id)
        {
            var where = string.Empty;
            var parameters = new List<SqlParameter>();
            #region Build Where Clause
            if (!string.IsNullOrEmpty(id))
            {
                where = $" WHERE op_id = @RowId  ";
                parameters.Add(new SqlParameter("RowId", id));
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[operators] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = AppConverter.ToAppOperator(row);
            return order;
        }
        public async Task<AppOperator> GetLoggedOperatorAsync(HttpContext httpContext)
        {
            var opId = GetLoggedOperatorId(httpContext);
            if (opId == "-1") return null;
            return await GetSingleAsync(opId);
        }
    }
}
