using Microsoft.EntityFrameworkCore;
using refund.ContextDir;
using refund.Libs;
using refund.Services;
using refund.Validators;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
if (!Directory.Exists(logFolderPath))
{
    Directory.CreateDirectory(logFolderPath);
}

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)  // Lee la configuración desde appsettings.json
    .Enrich.FromLogContext()
    .WriteTo.Console()  // Enviar logs a la consola
    .WriteTo.File(Path.Combine(logFolderPath, "log-.txt"), rollingInterval: RollingInterval.Day)  // Guardar logs en archivo diario
    .CreateLogger();
builder.Services.AddControllers();
// .AddNewtonsoftJson(options=>{
//             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            
// options.SerializerSettings.Error = (sender, args) =>
//         {
//             if (args.ErrorContext.Error is InvalidOperationException && args.ErrorContext.Member?.ToString() == "Context")
//             {
//                 args.ErrorContext.Handled = true;
//             }

//         };


// });
 


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

    builder.Services.AddDbContext<DbContextPlayer>(options =>{
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        
    });

        //defining services
        builder.Services.AddScoped<IIncometype,IncometypeLibs>();
        builder.Services.AddScoped<IFilingStatus,FilingStatusLibs>();
        builder.Services.AddScoped<ITaxPreparer,TaxPreparerLibs>();
        builder.Services.AddScoped<IValidators,ValidateLibs>();
        builder.Services.AddScoped<IStateValidators,ValidateLibs>();
        builder.Services.AddScoped<ICityValidate,ValidateLibs>();
        builder.Services.AddScoped<IState,StateLibs>();
        builder.Services.AddScoped<ICity,CityLibs>();
        builder.Services.AddScoped<IClient,ClientLibs>();
        



var app = builder.Build();

try
{
    // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally
{
    Log.CloseAndFlush();
}

