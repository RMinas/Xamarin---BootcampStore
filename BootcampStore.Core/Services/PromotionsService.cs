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
    public class PromotionsService : IPromotionsServices
    {
        private readonly IBootcampService _bootcampService;

        public PromotionsService(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        public Task CreatePromotionAsync(Promotion promotion, CancellationToken ct = default(CancellationToken))
        {
            return _bootcampService.PostAsync("promotions", promotion, ct);
        }

        public Task CreatePromotionAsync(string product, string storeId, int discount, CancellationToken ct = default(CancellationToken))
        {
            var promotion = new Promotion()
            {
                Id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Product = product,
                Discount = discount,
                StoreId = storeId
            };

            return CreatePromotionAsync(promotion, ct);
        }

        public Task<List<Promotion>> GetPromotionsAsync(string storeId, CancellationToken ct = default(CancellationToken))
        {
            //TODO: get promotion of specific Store (storeId)
            return _bootcampService.GetAsync<List<Promotion>>("promotions", ct);
        }
    }
}
