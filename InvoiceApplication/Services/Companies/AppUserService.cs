using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Companies
{
    public class AppUserService : IAppUserService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AppUserService(IDbContextFactory<AppDbContext> contextFactoy, AuthenticationStateProvider authenticationStateProvider)
        {
            _contextFactory = contextFactoy;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<List<AppUser>> GetAll()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.AppUsers.Include(u => u.Buyers).Include(u => u.Seller).ToListAsync();
        }

        public async Task<string> GetLoggedUserId()
        {
            var users = await GetAll();
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var authUser = authState.User;
            var user = users.FirstOrDefault(u => u.UserName == authUser.Identity.Name);
            if (user == null)
            {
                return string.Empty;
            }
            else
            {
                return user.Id;

            }
        }
        public async Task<AppUser> GetCurrentUser()
        {
            var users = await GetAll();
            var logedUserId = await GetLoggedUserId();
            var user = users.FirstOrDefault(u => u.Id == logedUserId);
            return user;

        }
    }
}
