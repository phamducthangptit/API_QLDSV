using API1.Data;
using API1.Interface;
using API1.Repository;
using API1.VnPay.Services;

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
builder.Services.AddSingleton<IVnPayServices, VnPayService>();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowVnPay",
//        builder => builder.WithOrigins("https://sandbox.vnpayment.vn/paymentv2/vpcpay.html")
//                          .AllowAnyHeader()
//                          .AllowAnyMethod());
//});
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
