using API1.Data;
using API1.Interface;
using API1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QLDSVContext>();
builder.Services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddTransient<ISinhVienRepository, SinhVienRepository>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();
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
