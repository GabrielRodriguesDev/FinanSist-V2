using System.Text;
using Finansist.CrossCutting;
using Finansist.WebAPI.Middleware;
using Finansist.WebAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

#region Environment Variable
Environment.SetEnvironmentVariable("BaseViaCEPUrl", builder.Configuration["External:BaseViaCEPUrl"]);
Environment.SetEnvironmentVariable("DomainCookie", builder.Configuration["DomainCookie"]);
#endregion

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

# region Cors
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", b =>
            {
                b.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:4200")
                    .WithOrigins("http://localhost:4210");
            }));
#endregion

#region Authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    options.Events = new JwtBearerEvents
    {

        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("X-Access-Token"))
            {
                context.Token = context.Request.Cookies["X-Access-Token"];
            }


            return Task.CompletedTask;
        },
    };
}); //.AddCookie(options =>
//    {
//        options.Cookie.SameSite = SameSiteMode.Strict;
//        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//        options.Cookie.IsEssential = true;
//    });
#endregion

#region Dependency Injection
ConfigureRepository.ConfigureDI(builder.Services);
ConfigureService.ConfigureDI(builder.Services);
ConfigureClient.ConfigureDI(builder.Services);
#endregion

var app = builder.Build();

#region Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}
else
{

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

#endregion

#region Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();
#endregion


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<NotifyHub>("/notify");
    });

app.MapControllers();

app.Run();
