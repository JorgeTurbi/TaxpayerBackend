using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using refund.ContextDir;
using refund.Libs;
using refund.Services;
using refund.Validators;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var apiBaseUrl = configuration["ApiSettings:BaseUrl"];
var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DbContextPlayer>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option=>{
//     option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//     {
//         ValidateIssuer=false,
//         ValidateAudience=false,
//         ValidateLifetime=true,
//         ValidateIssuerSigningKey=true,
//         // ValidIssuer=builder.Configuration["jwt:Issuer"],
//         // ValidAudience=builder.Configuration["jwt:Audience"],
//         IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]!))

//     };
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }
        );
    // options.AddPolicy("fixOrigins",

    //   builder =>
    //   {
    //       builder.WithOrigins(apiBaseUrl!)
    //           .AllowAnyHeader()
    //           .AllowAnyMethod();
    //   }
    // );

});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"]!)),
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret..")),
        ValidateIssuer = false, // No validar el emisor (issuer)
        ValidateAudience = false, // No validar la audiencia
        ClockSkew = TimeSpan.FromMinutes(10)
    };
});



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PATHWARD COMPANY",
        Version = "v2",
        Description = "Servicio de uso exclusivo de ",
        TermsOfService = new Uri("https://taxpro.com"),
        Contact = new OpenApiContact
        {
            Name = "TI Department",
            Email = "info@test.com",
            Url = new Uri("https://taxprox.com"),
        },
        License = new OpenApiLicense
        {
            Name = "Todos los derechos reservados",
            Url = new Uri("https://taxpro.com"),
        }



    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });


    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

});





//defining services
builder.Services.AddScoped<IIncometype, IncometypeLibs>();
builder.Services.AddScoped<IFilingStatus, FilingStatusLibs>();
builder.Services.AddScoped<ITaxPreparer, TaxPreparerLibs>();
builder.Services.AddScoped<IValidators, ValidateLibs>();
builder.Services.AddScoped<IStateValidators, ValidateLibs>();
builder.Services.AddScoped<ICityValidate, ValidateLibs>();
builder.Services.AddScoped<IState, StateLibs>();
builder.Services.AddScoped<ICity, CityLibs>();
builder.Services.AddScoped<IClient, ClientLibs>();
builder.Services.AddScoped<ILogin, LoginLibs>();
builder.Services.AddScoped<IPostalCode, PostalCodeLibs>();




var app = builder.Build();

try
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("AllowAllOrigins");
    // app.UseCors("fixOrigins");
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

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

