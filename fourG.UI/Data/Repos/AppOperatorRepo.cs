using fourG.UI;
using fourG.UI.Data.Interfaces;
using fourG.UI.Data.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using fourG.UI.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace fourG.UI.Data.Repo
{
    public class AppOperatorRepo : IAppOperator
    {
        private readonly IAppDbContext _db;
        private readonly IConfiguration _configuration;

        public AppOperatorRepo(IAppDbContext db, IConfiguration configuration)
        {
            this._db = db;
            this._configuration = configuration;
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
                var order = await new AppConverter(_db).ToAppOperator(row);
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
            }else
            {
                return null;
            }
            #endregion
            var sql = $"SELECT * FROM [dbo].[operators] {where} ";
            var resultData = await _db.GetDataAsync(sql, parameters);
            if (resultData == null) return null;
            DataRow row = resultData.Rows[0];
            var order = await new AppConverter(_db).ToAppOperator(row);
            return order;
        }
        public async Task<AppOperator> GetLoggedOperatorAsync(HttpContext httpContext)
        {
            var opId = GetLoggedOperatorId(httpContext);
            if (opId == "-1") return null;
            return await GetSingleAsync(opId);
        }

        public async Task<bool> IncreaseWrongPwdAttempts(string operatorId, int wrongAttempts = 0)
        {
            var maxWrongPasswordCount = _configuration.GetSection("SecurityRules:MaxWrongPasswordCount").Value ?? "3";
            var maxLockedDurationHours = _configuration.GetSection("SecurityRules:MaxLockedDurationHours").Value ?? "2";

            var where = " WHERE op_id = @OpId ";
            string sql = string.Empty;
            var parameters = new List<SqlParameter> {
                new SqlParameter("OpId", operatorId)
             };

            if (wrongAttempts < int.Parse(maxWrongPasswordCount))
            {
                sql = $"UPDATE [dbo].[operators] SET attempts = attempts + 1 {where} ";
            }
            else
            {
                parameters.Add(new SqlParameter("LockedToTime", DateTime.Now.AddHours(int.Parse(maxLockedDurationHours))));
                sql = $"UPDATE [dbo].[operators] SET lockedOn = @LockedToTime  {where} ";
            }

            var result = await _db.ExecuteSqlCommandAsync(sql, parameters);
            return result > 0;
        }

        public async Task<bool> PreSuccessLogin(string operatorId)
        {
            var where = " WHERE op_id = @OpId ";
            string sql = string.Empty;
            var parameters = new List<SqlParameter> {
                new SqlParameter("OpId", operatorId)
             };
            
            parameters.Add(new SqlParameter("CurrentTime", DateTime.Now));
            sql = $"UPDATE [dbo].[operators] SET lastLoggedOn = @CurrentTime, attempts=0  {where} ";

            var result = await _db.ExecuteSqlCommandAsync(sql, parameters);
            return result > 0;
        }

        public async Task LoginAsync(AppOperator user, string password)
        {
            
        }

        public IEnumerable<Claim> GetUserClaims(AppOperator user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Role.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }
        private IEnumerable<Claim> GetUserRoleClaims(AppOperator user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            //claims.AddRange(this.GetUserPermissionClaims(role));
            return claims;
        }

        public Task<bool> LoginAsync(string operatodId, string password, string secretKey)
        {
            throw new NotImplementedException();
        }
    }
}
