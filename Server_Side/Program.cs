//using Microsoft.Extensions.Options;

//var builder = WebApplication.CreateBuilder(args); builder.Services.AddControllersWithViews();
//// Add session services 
//builder.Services.AddDistributedMemoryCache(); // For session state
//builder.Services.AddSession(options => 
//{
//    options.Cookie.Name = "MySessionCookie"; 
//    options.IdleTimeout = System.TimeSpan.FromMinutes(30);
//    options.Cookie.IsEssential = true;
//});
//var app = builder.Build(); if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles(); // Use session middleware app.UseSession(); app.UseRouting(); 
//app.UseAuthorization();

//app.MapControllerRoute(name: "default",
//    pattern: "{controller=State}/{action=Add}/{id?}"); app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddDistributedMemoryCache(); // For session state
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MySessionCookie";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Use session middleware
app.UseSession();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=State}/{action=Add}/{id?}");

app.Run();
