using BootcampStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BootcampStore.Core.Services.Interfaces
{
    public interface IStoresService
    {
        Task<List<Store>> GetStoresAsync(CancellationToken ct = default(CancellationToken));
        Task CreateStoreAsync(Store store, CancellationToken ct = default(CancellationToken));
        Task CreateStoreAsync(string name, string address, string phone, string photoUrl, string lat, string lng,
            CancellationToken ct = default(CancellationToken));
        //Task DeleteStoreAsync
    }
}
