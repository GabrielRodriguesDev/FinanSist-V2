using Finansist.CrossCutting;
using Finansist.WebAPI.SignalR;
using Finansist.WebAPI.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

#region 
Environment.SetEnvironmentVariable("BaseViaCEPUrl", builder.Configuration["External:BaseViaCEPUrl"]);
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


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


app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapHub<ChatHub>("/chat");
//    });

app.MapControllers();

app.Run();
