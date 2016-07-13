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
    public class StoresService : IStoresService
    {
        private readonly IBootcampService _bootcampService;

        public StoresService(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        public Task CreateStoreAsync(Store store, CancellationToken ct = default(CancellationToken))
        {
            return _bootcampService.PostAsync("stores", store, ct);
        }

        public Task CreateStoreAsync(string name, string address, string phone, string photoUrl, string lat, string lng, CancellationToken ct = default(CancellationToken))
        {
            var store = new Store()
            {
                Id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Name = name,
                Address = address,
                Phone = phone,
                PhotoUrl = photoUrl,
                Lat = lat,
                Lng = lng
            };

            return CreateStoreAsync(store, ct);
        }

        public Task<List<Store>> GetStoresAsync(CancellationToken ct = default(CancellationToken))
        {
            return _bootcampService.GetAsync<List<Store>>("stores", ct);
        }
    }
}
