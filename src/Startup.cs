using System.Security.Claims;
using IYLTDSU.WebApp.Configuration;
using IYLTDSU.WebApp.Controllers;
using IYLTDSU.WebApp.Views.Home;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

public class Startup
{
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        var clientId = Configuration["CognitoOptions:ClientId"];
        var clientSecret = Configuration["CognitoOptions:ClientSecret"];
        var metaDataAddress = Configuration["CognitoOptions:MetaDataAddress"];
        var logoutUri = Configuration["CognitoOptions:LogOutUri"];
        var redirectUri = Configuration["CognitoOptions:RedirectUri"];

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        services.Configure<CognitoOptions>(Configuration.GetSection(CognitoOptions.Cognito));
        
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(options => options.Events.OnSigningIn = FilterGroupClaims)
            .AddOpenIdConnect(options =>
            {
                options.ResponseType = "code";
                options.MetadataAddress = metaDataAddress;
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("email");
                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUrl = logoutUri;
                        logoutUrl += $"?client_id={clientId}&logout_uri={redirectUri}";
                        context.Response.Redirect(logoutUrl);
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }
                };
            });

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
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

    }
    
    private static Task FilterGroupClaims(CookieSigningInContext context)
    {
        var principal = context.Principal;
        if (principal.Identity is ClaimsIdentity identity)
        {
            var unused = identity.FindAll(GroupsToRemove).ToList();
            unused.ForEach(c => identity.TryRemoveClaim(c));
        }
        return Task.FromResult(principal);
    }

    private static bool GroupsToRemove(Claim claim)
    {
        string[] _groupObjectIds = new string[] { "identities" };
        return claim.Type == "groups" && !_groupObjectIds.Contains(claim.Type);
    }
}