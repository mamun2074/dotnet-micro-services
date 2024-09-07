
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data;

public class CacheBasketRepository(IDistributedCache _distributedCache, IBasketRepository _basketRepository) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var cacheBasket = await _distributedCache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(cacheBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket)!;
        }
        var baske = await _basketRepository.GetBasket(userName, cancellationToken);
        await _distributedCache.SetStringAsync(userName, JsonSerializer.Serialize(baske));
        return baske;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        await _basketRepository.StoreBasket(basket, cancellationToken);
        await _distributedCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }
    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        await _basketRepository.DeleteBasket(userName, cancellationToken);
        await _distributedCache.RemoveAsync(userName, cancellationToken);
        return true;
    }
}
