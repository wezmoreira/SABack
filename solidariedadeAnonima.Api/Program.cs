using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using solidariedadeAnonima.Api.Setup;
using solidariedadeAnonima.Domain.Handlers.Entities;
using solidariedadeAnonima.Domain.Handlers.Pages;
using solidariedadeAnonima.Domain.Handlers.Security;
using solidariedadeAnonima.Domain.Interfaces;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Domain.Security;
using solidariedadeAnonima.Infra.Context;
using solidariedadeAnonima.Infra.Repositories;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


ConfigureMvc(builder);
ConfigureDatabase(builder);
ConfigureCors(builder);

Dependencies(builder);
ConfigureSwagger(builder);
Security(builder);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();




void Dependencies(WebApplicationBuilder builder)
{
    #region Repositories
    builder.Services.AddScoped<IHomeRepository, HomeRepository>();
    builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
    builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IJwtProvider, JwtProvider>();
    #endregion

    #region Handlers
    builder.Services.AddScoped<RegisterHandler, RegisterHandler>();
    builder.Services.AddScoped<HomeHandler, HomeHandler>();
    builder.Services.AddScoped<UserHandler, UserHandler>();
    builder.Services.AddScoped<LoginHandler, LoginHandler>();
    #endregion
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services
        .AddControllers().AddNewtonsoftJson(x =>
        {
            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            x.SerializerSettings.Converters.Add(new StringEnumConverter());
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });
}


void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


void ConfigureDatabase(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));
}

void ConfigureCors(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

//void Security(WebApplicationBuilder builder)
//{
//    var key = Encoding.ASCII.GetBytes(Settings.Secret);
//    builder.Services.AddAuthentication(x =>
//    {
//        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(x =>
//    {
//        x.RequireHttpsMetadata = false;
//        x.SaveToken = true;
//        x.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(key),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });

//    builder.Services.AddHttpContextAccessor();
//}

void Security(WebApplicationBuilder builder)
{
    builder.Services.ConfigureOptions<JwtOptionsSetup>();
    builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
}