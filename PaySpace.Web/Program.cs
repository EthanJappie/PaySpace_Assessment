using PaySpace.Web;
using PaySpace.Web.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpForwarder();
builder.Services.AddScoped<IAuthClient,AuthClient>();

var payspaceUrl = builder.Configuration["PaySpaceApiUrl"] ??
              throw new InvalidOperationException("PaySpace API URL is not configured");

builder.Services.AddHttpClient<AuthClient>(client =>
{
    client.BaseAddress = new Uri(payspaceUrl);
});

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

//Configure Api's
app.MapTax(payspaceUrl);

app.Run();
