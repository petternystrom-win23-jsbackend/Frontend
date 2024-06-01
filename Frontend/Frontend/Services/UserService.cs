using Frontend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserService> _logger;

        public ApplicationUser CurrentUser { get; private set; } = new ApplicationUser();

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task LoadUserDataAsync()
        {
            try
            {
                var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
                if (!string.IsNullOrEmpty(userId))
                {
                    var user = await _userManager.Users
                        .Include(x => x.Address)
                        .FirstOrDefaultAsync(x => x.Id == userId);

                    if (user != null)
                    {
                        CurrentUser = user;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading user data");
            }
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            try
            {
                var result = await _userManager.UpdateAsync(user);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user data");
                return false;
            }
        }
    }
}
