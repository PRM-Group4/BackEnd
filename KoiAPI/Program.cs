using KoiAPI.AppStarts;
using Repos.Interface;
using Repos;
using Services.IServices;
using Services;
using Microsoft.OpenApi.Models;
using BOs.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter a valid token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
//Dependency Injection
builder.Services.InstallService(builder.Configuration);
builder.Services.AddWebAPIService();



//odata
builder.Services.AddControllers().AddOData(option => option.Select().Filter()
.Count().OrderBy().Expand().SetMaxTop(100)
.AddRouteComponents("odata", GetEdmModel()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseODataBatching();

//test middleware
app.Use(async (context, next) =>
{
    var endpoint = context.GetEndpoint();
if (endpoint == null)
{
    await next(); // Gọi middleware tiếp theo
    return;
}

IEnumerable<string> templates;
IODataRoutingMetadata metadata =
    endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
if (metadata != null)
{
    templates = metadata.Template.GetTemplates();
}

await next(); // Gọi middleware tiếp theo
});
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<User>("user");




    var userEntity = builder.EntityType<User>();
    userEntity.HasKey(r => r.UserId);

    return builder.GetEdmModel();
}