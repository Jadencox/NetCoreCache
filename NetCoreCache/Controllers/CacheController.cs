using Cache;
using CoreCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreCache.Models;
using Newtonsoft.Json;

namespace NetCoreCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        [Route("SetCache")]
        [HttpPost]
        public bool SetCache(string Key, string Value)
        {
            var MyCache = CacheHandler.TryGet<string>(CacheKeyConstants.MyCache, CacheNameConstants.DoCare_Caching_Default);
            if (string.IsNullOrEmpty(MyCache)) 
            {
                CacheHandler.Set(CacheKeyConstants.MyCache, "MyCache11111", CacheNameConstants.DoCare_Caching_Default);
            }

            return true;
        }

        [Route("GetCache")]
        [HttpGet]
        public string GetCache()
        {
            var MyCache = CacheHandler.TryGet<string>(CacheKeyConstants.MyCache, CacheNameConstants.DoCare_Caching_Default);
            return MyCache ?? "";
        }

        [Route("RemoveCache")]
        [HttpGet]
        public bool RemoveCache()
        {
            CacheHandler.Remove(CacheKeyConstants.MyCache, CacheNameConstants.DoCare_Caching_Default);
            return true;
        }

        [Route("SetCacheList")]
        [HttpPost]
        public bool SetCacheList(string Key, string Value)
        {
            SysUser SysUser = new SysUser() { UserName = "jaden", LoginPwd = "123"};
            var MyCache = CacheHandler.TryGet<SysUser>(CacheKeyConstants.MyCacheUser, CacheNameConstants.DoCare_Caching_Default);
            if (MyCache == null)
            {
                CacheHandler.Set(CacheKeyConstants.MyCacheUser, SysUser, CacheNameConstants.DoCare_Caching_Default);
            }

            return true;
        }

        [Route("GetCacheList")]
        [HttpGet]
        public string GetCacheList()
        {
            var MyCache = CacheHandler.TryGet<SysUser>(CacheKeyConstants.MyCacheUser, CacheNameConstants.DoCare_Caching_Default);
            if (MyCache != null) 
            {
                return JsonConvert.SerializeObject(MyCache);

            }
            return "";
        }

        [Route("RemoveCacheList")]
        [HttpGet]
        public bool RemoveCacheList()
        {
            CacheHandler.Remove(CacheKeyConstants.MyCacheUser, CacheNameConstants.DoCare_Caching_Default);
            return true;
        }
    }
}
