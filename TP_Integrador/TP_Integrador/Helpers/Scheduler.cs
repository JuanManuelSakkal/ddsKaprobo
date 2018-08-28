using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace TP_Integrador.Helpers
{
    public static class Scheduler
    {
        public static void Schedule()
        {
            HttpContext.Current.Cache.Add("Prueba", "Prueba2", null, DateTime.MaxValue, TimeSpan.FromSeconds(5), CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }

        public static void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            System.Diagnostics.Debug.WriteLine("Cache item callback: " + DateTime.Now.ToString());
            HttpContext.Current.Cache.Add("Prueba", "Prueba2", null, DateTime.MaxValue, TimeSpan.FromSeconds(5), CacheItemPriority.Normal, new CacheItemRemovedCallback(CacheItemRemovedCallback));
        }
    }
}