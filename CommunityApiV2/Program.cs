using CommunityApiV2.Data;
using CommunityApiV2.Repositories;
using CommunityApiV2.Repositories.Interfaces;
using CommunityApiV2.Services;
using CommunityApiV2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddDbContext<CommunityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CommunityAPI v2");
        options.RoutePrefix = string.Empty;
    });
}



app.MapControllers();

app.Run();
