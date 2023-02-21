var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                      });
});


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
startup.Configure(app, builder.Environment); // 
