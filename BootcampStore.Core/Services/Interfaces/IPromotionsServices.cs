using BootcampStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BootcampStore.Core.Services.Interfaces
{
    public interface IPromotionsServices
    {
        Task<List<Promotion>> GetPromotionsAsync(string storeId, CancellationToken ct = default(CancellationToken));
        Task CreatePromotionAsync(Promotion promotion, CancellationToken ct = default(CancellationToken));
        Task CreatePromotionAsync(string product, string storeId, int discount, CancellationToken ct = default(CancellationToken));
        //Task DeleteStoreAsync
        //Task DeletePromotionAsync
    }
}
