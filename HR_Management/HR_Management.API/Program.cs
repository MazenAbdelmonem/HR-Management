using System.Text;
using HR_Management.API.Data;
using HR_Management.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeRepository,SQLEmployeeRepository>();
builder.Services.AddScoped<IAttendanceRepository,SQLAttendanceRepository>();
builder.Services.AddScoped<ILeaveRepository,SQLLeaveRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<HRManagementDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("HRManagementConnectionString")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
{
    //ValidateIssuer = true,
    //ValidateAudience = true,
    //ValidateIssuerSigningKey = true,
    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
    //ValidAudience = builder.Configuration["Jwt:Audience"],
    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidAudience = builder.Configuration["JWT:Audience"],
    IssuerSigningKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
});
builder.Services.AddSwaggerGen();

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
