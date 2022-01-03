using ContactManager.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ContactService>();
builder.Services.AddDbContext<ContactDbContext>(item => item.UseSqlite("Data Source=contacts.db"));
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

//SyncFusion License Key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU3ODMyQDMxMzkyZTM0MmUzMFFpbWRpUm5xZ25ZVTdGcEZHQTlRTkM2bkdyckIzb1loSGNVejhRYlZTSE09");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

