using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Application.Abstraction.ExternalServices;
using TheFrogGames.Application.Service;
using TheFrogGames.Domain.Entities;
using TheFrogGames.Infraestructure.ExternalServices;
using TheFrogGames.Infraestructure.Persistence.Repository;
using TheFrogGames.Infrastructure.ExternalServices;
using TheFrogGames.Infrastructure.Options;
using TheFrogGames.Infrastructure.Persistence;
using TheFrogGames.Infrastructure.Persistence.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "FrontendCorsPolicy",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<TheFrogGamesDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(nameof(TypeRole.SysAdmin), policy => policy.RequireRole(nameof(TypeRole.SysAdmin)));
    options.AddPolicy(nameof(TypeRole.Admin), policy => policy.RequireRole(nameof(TypeRole.Admin)));
    options.AddPolicy(nameof(TypeRole.User), policy => policy.RequireRole(nameof(TypeRole.User)));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IGenreService, GenreService>();


builder.Services.Configure<GamesApiOptions>(
builder.Configuration.GetSection("GamesApiOptions"));

builder.Services.AddHttpClient<IExternalGameService, GamesFromFirebaseService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendCorsPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
