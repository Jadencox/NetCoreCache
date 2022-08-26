namespace NetCoreCache
{
    /// <summary>
    /// 注册一个静态的server provider
    /// 不然多线程的时候，拿不到context 里的 service provider 报错
    /// </summary>
    public static class ServiceProviderHelper
    {
        public static void Configure(IServiceProvider serviceProvider)
        {
            ServiceProvider1 = serviceProvider;
        }

        public static IServiceProvider ServiceProvider1 { get; private set; }

    }
}
