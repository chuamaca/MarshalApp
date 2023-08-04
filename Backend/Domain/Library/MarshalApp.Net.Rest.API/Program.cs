using MarshalApp.Net.Rest.Infrastructure.Data.Contexts;
using MarshalApp.Net.Rest.API.ApplicationServices;
using MarshalApp.Net.Rest.API.Infrastructure.LinksBuilders;
using MarshalApp.Net.Rest.API.Infrastructure.Mapper;
using MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers.TypeHelper;
using MarshalApp.Net.Rest.Infrastructure.Data.Helpers;
using MarshalApp.Net.Rest.Infrastructure.Data.Repositories;
using MarshalApp.Net.Rest.Infrastructure.Data.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Buffers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("LibraryConnectionString");

builder.Services.AddControllers(opt =>
{
    var serializerSettings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        ContractResolver = new DefaultContractResolver()
    };

    opt.OutputFormatters.Add(new NewtonsoftJsonOutputFormatter(serializerSettings, ArrayPool<char>.Shared, new MvcOptions()));
    opt.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
    opt.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(new MvcOptions()));

    var xmlDataContractSerializerInputFormatter = new XmlDataContractSerializerInputFormatter(new MvcOptions());
    xmlDataContractSerializerInputFormatter.SupportedMediaTypes.Add("application/vnd.cesar.authorwithdateofdeath.full+xml");
    opt.InputFormatters.Add(xmlDataContractSerializerInputFormatter);

    var jsonInputFormatter = opt.InputFormatters.OfType<SystemTextJsonInputFormatter>().FirstOrDefault();
    if (jsonInputFormatter != null)
    {
        jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.cesar.author.full+json");
        jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.cesar.authorwithdateofdeath.full+json");
    }

    var jsonOutputFormatter = opt.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();
    if (jsonOutputFormatter != null)
    {
        jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.cesar.hateoas+json");
    }

    var newtonsoftJsonOutputFormatter = opt.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>().FirstOrDefault();
    if (newtonsoftJsonOutputFormatter != null)
    {
        newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.cesar.hateoas+json");
    }

    opt.Filters.Add(new AuthorizeFilter());
})
.AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescription => apiDescription.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
          Enter 'Bearer' [space] and then your token in the text input below.
          \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<LibraryContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(LibraryProfile));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();

builder.Services.AddScoped<IInfohdrRepository, InfohdrRepository>();


//Documentacion
builder.Services.AddScoped<LibraryUnitOfWork>();
builder.Services.AddScoped<IAuthorLinksBuilder, AuthorLinksBuilder>();
builder.Services.AddScoped<IBookLinksBuilder, BookLinksBuilder>();

builder.Services.AddScoped<IStudentLinksBuilder, StudentLinksBuilder>();
builder.Services.AddScoped<IGradeLinksBuilder, GradeLinksBuilder>();

builder.Services.AddScoped<ITechnicalreportsLinksBuilder, TechnicalreportsLinksBuilder>();

builder.Services.AddScoped<IRootLinksBuilder, RootLinksBuilder>();
builder.Services.AddScoped<ITypeHelperService, TypeHelperService>();

#region MapeoDeService

builder.Services.AddTransient<IAuthorPropertyMappingService, AuthorPropertyMappingService>();
builder.Services.AddTransient<IStudentPropertyMappingService, StudentPropertyMappingService>();
//Technicalreports
builder.Services.AddTransient<IInfohdrPropertyMappingService, InfohdrPropertyMappingService>();

#endregion

builder.Services.AddScoped<ILibraryApplicationService, LibraryApplicationService>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["SecuritySettings:Issuer"],
        ValidAudience = builder.Configuration["SecuritySettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecuritySettings:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAllCORS", policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllCORS");
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

SeeData(app);

app.Run();

void SeeData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
        context.EnsureSeedDataForContext();
    }
}