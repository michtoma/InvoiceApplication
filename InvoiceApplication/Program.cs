using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using InvoiceApplication.Services.Companies;
using InvoiceApplication.Services.Invoices;
using InvoiceApplication.Services.Items;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContext2");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextFactory<AppDbContext>(option =>
    option.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IVatRateService, VatRateService>();
builder.Services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceItemService, InvoiceItemService>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IAddresService, AddresService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<INumberGenerator, NumberGenerator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
