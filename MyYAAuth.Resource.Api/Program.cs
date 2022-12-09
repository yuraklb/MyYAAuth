using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyAuth.UI.Requirements;
using MyYAAuth.Auth.Common;
using MyYAAuth.Resource.Api.Extensions;
using MyYAAuth.Resource.Api.Requirements.Age;
using MyYAAuth.Resource.Api.Requirements.Gender;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();



// Add services to the container.


// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
var authOptions = configuration.GetSection("Auth").Get<AuthOptions>();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authOptions.Issuer,
        ValidateAudience = true,
        // ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidAudience = authOptions.Audience,
        ValidateLifetime = true,
        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("age-policy", policy => policy.RequireClaim("age"));
    options.AddPolicy("age-policy2", policy => policy.Requirements.Add(new AgeRequirement(42)));
    options.AddPolicy("gender-policy", policy => policy.Requirements.Add(new GenderRequirement("male")));

    //options.AddPolicy("resource-allow-policy", x => { x.AddRequirements(new ResourceBasedRequirement()); });

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth.Resource.Api", Version = "v1" });
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
                        new List<string>()
                    }
                });
            });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.RegisterCustomOptions(configuration);
builder.Services.RegisterCustomServices();
builder.Services.RegisterAuthorizationHandlers();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth.Resource.Api v1"));

}

//app.UseHttpsRedirection();


app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // endpoints.Map("/hello", [Authorize] (context) =>
    // {
    //     return Task.FromResult("Hello World!");
    // });
    // endpoints.Map("/qqq", (context) =>
    // {
    //     return Task.FromResult("Home Page");
    // });
    endpoints.MapControllers();
});

app.Run();
