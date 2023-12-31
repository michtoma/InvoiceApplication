using InvoiceApplication.Models.Companies;

namespace InvoiceApplication.Services.Companies
{
    public interface IAppUserService
    {
        Task<List<AppUser>> GetAll();
        Task<string> GetLoggedUserId();
        Task<AppUser> GetCurrentUser();
    }
}
