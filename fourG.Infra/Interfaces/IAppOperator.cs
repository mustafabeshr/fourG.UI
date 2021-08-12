using fourG.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fourG.Infra.Interfaces
{
    public interface IAppOperator
    {
        Task<List<AppOperator>> GetListAsync(int status, int role);
        Task<AppOperator> GetSingleAsync(string id);
        string GetLoggedOperatorId(HttpContext httpContext);
        int GetLoggedOperatorRoleId(HttpContext httpContext);
        Task<AppOperator> GetLoggedOperatorAsync(HttpContext httpContext);
    }
}
