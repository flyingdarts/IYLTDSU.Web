using IYLTDSU.WebApp.Configuration;
using IYLTDSU.WebApp.Controllers;
using IYLTDSU.WebApp.Views.Home;

public class Startup
{
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CognitoOptions>(Configuration.GetSection(CognitoOptions.Cognito));

        services.AddSingleton<HomePageViewModel>();

        services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

        services.AddRazorPages();
        services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

        services.AddHttpClient<HomeController>();
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

    }
}