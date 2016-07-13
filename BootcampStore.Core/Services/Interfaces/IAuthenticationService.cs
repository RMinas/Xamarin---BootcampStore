using BootcampStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BootcampStore.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task LoginAsync(string username, string password, CancellationToken ct = default(CancellationToken));
        Task LogoutAsync(CancellationToken ct = default(CancellationToken));
        bool IsUserAuthenticated();
        UserType GetAuthenticatedUserType();
    }
}
