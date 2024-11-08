using KOI_XS.BLL;
using KOI_XS.BLL;
using KOI_XS.DAL;
using KOI_XS.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đọc chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Cấu hình DbContext cho DAL
builder.Services.AddDbContext<KoiContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký các repository trong DAL
builder.Services.AddScoped<KoiContext, KoiContext>();

// Đăng ký các dịch vụ trong BLL
builder.Services.AddScoped<KoiService, KoiService>();

// Thêm dịch vụ MVC vào container
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
