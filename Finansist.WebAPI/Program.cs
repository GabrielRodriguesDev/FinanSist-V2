using Finansist.CrossCutting;
using Finansist.WebAPI.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

#region 
Environment.SetEnvironmentVariable("BaseViaCEPUrl", builder.Configuration["External:BaseViaCEPUrl"]);
#endregion

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", b =>
            {
                b.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:4200");
            }));



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
//app.UseMiddleware<ErrorHandlerMiddleware>();
#endregion


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("CorsPolicy");


app.UseEndpoints(endpoints =>
   {
       endpoints.MapHub<NotifyHub>("/notify");
   });

app.MapControllers();

app.Run();
