using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace lab17.Controllers
{
    public class CacheController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<CacheController> _logger;

        public CacheController(IMemoryCache memoryCache, IDistributedCache distributedCache,
            ILogger<CacheController> logger)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public IActionResult MemoryCacheView()
        {
            const string cacheKey = "TimeNow";
            if (!_memoryCache.TryGetValue(cacheKey, out string time))
            {
                time = DateTime.Now.ToString("T");
                _memoryCache.Set(cacheKey, time, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10),
                    SlidingExpiration = TimeSpan.FromSeconds(5)
                });
                ViewBag.CacheStatus = "MISS";
            }
            else
            {
                ViewBag.CacheStatus = "HIT";
            }

            ViewBag.Time = time;
            return View("MemoryCacheDemo", time);
        }

        public async Task<IActionResult> DistributedCacheDemo()
        {
            const string cacheKey = "distTime";
            var timeBytes = await _distributedCache.GetAsync(cacheKey);
            string time;

            if (timeBytes == null)
            {
                time = DateTime.Now.ToString("T");
                var encoded = Encoding.UTF8.GetBytes(time);
                await _distributedCache.SetAsync(cacheKey, encoded, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
                ViewBag.CacheStatus = "MISS";
            }
            else
            {
                time = Encoding.UTF8.GetString(timeBytes);
                ViewBag.CacheStatus = "HIT";
            }

            ViewBag.Time = time;
            return View("MemoryCacheDemo", time);
        }

        [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Client)]
        public IActionResult ResponseCacheDemo()
        {
            ViewBag.CacheStatus = "BROWSER CACHE";
            var time = DateTime.Now.ToString("T");
            ViewBag.Time = time;
            return View("MemoryCacheDemo", time);
        }
    }
}
