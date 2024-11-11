using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Attendance_WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ DbContext vào DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm các dịch vụ cần thiết vào container
builder.Services.AddRazorPages(); // Nếu bạn sử dụng Razor Pages

builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

// Cấu hình middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Chỉ cho môi trường phát triển
}
else
{
    app.UseExceptionHandler("/Error"); // Trang lỗi
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); // Định tuyến các trang Razor

app.Run();
