using BootcampStore.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootcampStore.Core.Models;
using System.Threading;

namespace BootcampStore.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private User user;
        private readonly IBootcampService _bootcampService;

        public AuthenticationService(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        public UserType GetAuthenticatedUserType()
        {
            throw new NotImplementedException();
        }

        public bool IsUserAuthenticated()
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(string username, string password, CancellationToken ct = default(CancellationToken))
        {
            user = new User()
            {
                Username = username,
                Password = password
            };

            return _bootcampService.PostAsync("Users/Login", user, ct);
        }

        public async Task LogoutAsync(CancellationToken ct = default(CancellationToken))
        {
            await Task.Delay(1000, ct);
            user = null;
        }
    }
}
