namespace lab17
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMemoryCache();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = _configuration.GetConnectionString("Redis") ?? "localhost:6379";
                options.InstanceName = "CacheDemo:";
            });

            services.AddResponseCaching();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseRouting();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cache}/{action=MemoryCacheView}/{id?}");
            });
        }
    }
}
