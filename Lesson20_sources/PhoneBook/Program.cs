using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PhoneBook.Controllers;
using PhoneBook.Data;
using PhoneBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });


builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddApplicationPart(typeof(ContactsController).Assembly);

// ��������� ��������� MVC (���� ������������ Razor Pages)
builder.Services.AddControllersWithViews(); // ��� MVC
// ���, ���� ����������� Razor Pages:
// builder.Services.AddRazorPages();

// ��������� DbContext
builder.Services.AddDbContext<PhoneBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PhoneBookContext")));

// ����������� ������� IContactService
builder.Services.AddScoped<IContactService, ContactService>(); // <- ��� ��� ����� ��������

// ������������ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PhoneBook API",
        Version = "v1",
        Description = "API ��� ����������� �����������"
    });
});

var app = builder.Build();

// �������� middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook API v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contacts}/{action=Search}/{id?}");

app.Run();