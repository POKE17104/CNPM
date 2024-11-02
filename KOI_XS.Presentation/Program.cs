// KOI_XS.Presentation/Program.cs
using KOI_XS.DAL;
using KOI_XS.BLL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ DbContext với chuỗi kết nối từ appsettings.json
builder.Services.AddDbContext<KoiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm KoiService vào Dependency Injection (DI)
builder.Services.AddScoped<KoiService>();

// Thêm các dịch vụ khác
builder.Services.AddControllers();

// Thêm Swagger để dễ dàng test API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
