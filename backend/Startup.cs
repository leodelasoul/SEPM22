
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Service;
public class Startup{
    public IConfiguration config {get;}

    public Startup(IConfiguration configuration){
        config = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connection = config.GetConnectionString("DBConnection");
   


        services.AddDbContext<WendyDbContext>(options =>
            options.UseSqlServer(
                connection),
                ServiceLifetime.Transient); //set to transient as services are defined in this lifecycle, the standard config is scoped

        services.AddTransient<IOwnerService, OwnerService>();
        services.AddTransient<IHorseService, HorseService>();


        services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true); // described by the bool value quite good
     
    }
      public void Configure(WebApplication app, IWebHostEnvironment env) {
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }


}
