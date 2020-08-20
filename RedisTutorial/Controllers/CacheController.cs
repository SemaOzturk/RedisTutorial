using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisTutorial.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedisTutorial.Controllers
{
    [Route("api/[controller]")]
    public class CacheController : Controller
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        [HttpGet("cache/{key}")]
        public async Task<IActionResult> GetCacheValue([FromRoute] string key)
        {
            var value = await _cacheService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ? (IActionResult) NotFound() : Ok(value);
        }
        [HttpPost("cache")]

        public async Task<IActionResult> SetCacheValue([FromBody] NewCacheEntryRequest request)
        {
            await _cacheService.SetCacheValueAsync(request.Key, request.Value);
            return Ok();
        }
    }
}
