using fourG.Web;
using fourG.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Web.Data.Interfaces
{
    public interface IAppOperator
    {
        Task<List<AppOperator>> GetListAsync(int status, int role);
        Task<AppOperator> GetSingleAsync(string id);
        string GetLoggedOperatorId(HttpContext httpContext);
        int GetLoggedOperatorRoleId(HttpContext httpContext);
        Task<AppOperator> GetLoggedOperatorAsync(HttpContext httpContext);
        Task<bool> IncreaseWrongPwdAttempts(string operatorId, int wrongAttempts);
        Task<bool> PreSuccessLogin(string operatorId);
        Task<bool> LoginAsync(string operatodId, string password, string secretKey);
        IEnumerable<Claim> GetUserClaims(AppOperator user);
    }
}
