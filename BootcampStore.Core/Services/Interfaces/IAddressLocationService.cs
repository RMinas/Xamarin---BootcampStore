using BootcampStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BootcampStore.Core.Services.Interfaces
{
    public interface IAddressLocationService
    {
        Task<GeoLocation> GetLocationAsync(string address, CancellationToken ct = default(CancellationToken));
    }
}
