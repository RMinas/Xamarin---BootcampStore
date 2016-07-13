using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BootcampStore.Core.Services.Interfaces
{
    public interface IBootcampService
    {
        Task<T> GetAsync<T>(string requrestUri, CancellationToken ct = default(CancellationToken)) where T : class, new();
        Task PostAsync<T>(string requestUri, T content, CancellationToken ct = default(CancellationToken)) where T : class, new();
    }
}
