using Blazored.SessionStorage;
using fourG.UI.Data.Entities;
using fourG.UI.Data.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace fourG.UI.Data.Utility
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private readonly IAppOperator _appOperator;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService, IAppOperator appOperator)
        {
            this._sessionStorageService = sessionStorageService;
            this._appOperator = appOperator;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userId = await _sessionStorageService.GetItemAsStringAsync("OperatorId");
            var currentOperator = await _appOperator.GetSingleAsync(userId);
            ClaimsIdentity identity;
            if (currentOperator != null)
            {
                identity = GetClaimsIdentity(currentOperator);
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            //var identity = new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Name ,"mustafa"),
            //}, "apiAyth");

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public async Task MarkUserAsAuthenticated(AppOperator user)
        {
            await _sessionStorageService.SetItemAsStringAsync("OperatorId", user.Id);

            var identity = GetClaimsIdentity(user);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _sessionStorageService.RemoveItemAsync("OperatorId");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        private ClaimsIdentity GetClaimsIdentity(AppOperator user)
        {
            var claimsIdentity = new ClaimsIdentity();

            if (user.Id != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, user.Name),
                                    new Claim(ClaimTypes.Role, user.Role.Name),
                                    new Claim(ClaimTypes.GivenName, user.Role.Id.ToString())
                                }, "apiauth_type");
            }

            return claimsIdentity;
        }


    }
}
