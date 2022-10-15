using EsitCV.API.Filters;
using EsitCV.Business.AutoMapper;
using EsitCV.Business.Extensions;
using EsitCV.Shared.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<JsonExceptionFilter>();
    //options.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EsitCV.API", Version = "1.0.0" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                     Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {{
        new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            },
            Scheme="oauth2",
            Name="Bearer",
            In=ParameterLocation.Header,
        },
        new List<string>() }
    });
});
IdentityModelEventSource.ShowPII = true;

builder.Services.AddOptions();
builder.Services.AddMemoryCache();

//builder.Services.AddDistributedRedisCache(option =>
//{
//    option.Configuration = ""; //redis kullan�laca�� zaman a��lacak
//    //option.Configuration = "127.0.0.1:6379";
//});

builder.Services.AddHttpContextAccessor();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<EsitCV.Shared.Utilities.Security.Jwt.TokenOptions>();
builder.Services.AddLogging();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };

    //options.Authority = "/portfolio" /* TODO: Insert Authority URL here */;
    options.RequireHttpsMetadata = false;
    // We have to hook the OnMessageReceived event in order to
    // allow the JWT authentication handler to read the access
    // token from the query string when a WebSocket or 
    // Server-Sent Events request comes in.

    // Sending the access token in the query string is required due to
    // a limitation in Browser APIs. We restrict it to only calls to the
    // SignalR hub in this code.
    // See https://docs.microsoft.com/aspnet/core/signalr/security#access-token-logging
    // for more information about security considerations when using
    // the query string to transmit the access token.
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/portfolio")))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
options.AddPolicy("Role",
    policy => policy.RequireClaim(claimType: ClaimTypes.Role, "Admin", "User","Company")));

builder.Services.AddAutoMapper(typeof(AboutProfile), typeof(AnswerProfile), typeof(AreasOfInterestProfile), typeof(CurriculumVitaeProfile),
    typeof(CompanyPictureProfile), typeof(CompanyProfile), typeof(CourseProfile), typeof(CurrentProjectProfile), typeof(DisabilityProfile),
    typeof(EducationProfile), typeof(HobbieProfile), typeof(JobApplicationProfile), typeof(JobPostingProfile), typeof(LanguageProfile),
    typeof(LicenseOrCertificateProfile), typeof(LocationProfile), typeof(OrganizationProfile), typeof(QuestionProfile), typeof(UserPictureProfile), typeof(UserProfile), typeof(UserProfileProfile), typeof(WorkExperienceProfile));
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.LoadMyServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
