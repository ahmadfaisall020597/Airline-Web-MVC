using AirlineBooking.Models;
using AirlineBooking.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddDbContext<AirlineBookingDbContext>(
    options => options.UseSqlServer("name=ConnectionStrings:AIRLINE_BOOKING")
);

/*builder.Services.AddControllers();*/
builder.Services.AddControllersWithViews();
/*builder.Services.AddEndpointsApiExplorer();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (!(context.Request.Path == "" ||
          context.Request.Path == "/" ||
          context.Request.Path.StartsWithSegments("/Admin/Login")  ||
          context.Request.Path.StartsWithSegments("/Admin/Login/Login") ||
          context.Request.Path.StartsWithSegments("/Admin/Login/Index") ||
          context.Request.Path.StartsWithSegments("/Admin/Error") ||
          context.Request.Path.StartsWithSegments("/Admin/Error/Index")
          
        )
       )
    {

        var _token = "";
        try
        {
            
            if (context.Request.Method == "GET")
            {
                var _t = context.GetRouteValue("t");
                if (_t != null)
                {
                    _token = _t.ToString();
                }
            
                if (string.IsNullOrEmpty(_token))
                {
                    _token = context.Request.Query["t"];   
                }
            
                if (string.IsNullOrEmpty(_token))
                {
                    if (context.Request.Headers.ContainsKey("t"))
                    {
                        var _t1 = context.Request.Headers["t"];
                        _token = _t1.ToString();    
                    }
                }
            
            }
            else
            {
                if (context.Request.Headers.ContainsKey("t"))
                {
                    var _t = context.Request.Headers["t"];
                    _token = _t.ToString();
                    
                }
                else
                {
                    if (context.Request.Form.ContainsKey("t"))
                    {
                        _token = context.Request.Form["t"];
                    }
                }
            }
        }
        catch (Exception e)
        {
            context.Response.Redirect("/Admin/Login?Message=" + e.Message);
            return;
        }
       
        if (!string.IsNullOrEmpty(_token))
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<AirlineBookingDbContext>();
            if (db != null)
            {
                AdminLoginService _adminLoginService = new AdminLoginService(db, "");
                try
                {
                    var _login = _adminLoginService.FindByLoginID(_token);
                    context.Items["LoginID"] = _login.AdminUser;
                    await next.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    context.Response.Redirect("/Admin/Error?Message=" + ex.Message);
                    return;
                }
            }
            else
            {
                var _msg = "Cannot connect to db";
                context.Response.Redirect("/Admin/Error?Message=" + _msg);
                return;
            }
        }
        else
        {
            var _msg = "Invalid Token";
            context.Response.Redirect("/Admin/Login?Message=" + _msg);
            return;
        }
    }
    else
    {
        await next.Invoke();
    }
});



/*
 details  (lebih panjang) => lebih umum (lebih pendek)  
 */

/*app.MapControllers();*/


app.MapAreaControllerRoute("admin_with_token",
    "Admin",
    "Admin/{controller=AdminUser}/{action=Index}/{t}/{id?}");

app.MapAreaControllerRoute("admin",
    "Admin",
    "Admin/{controller=Airport}/{action=Index}/{id?}");


app.MapAreaControllerRoute("passenger",
    "Passenger",
    "Passenger/{controller=Login}/{action=Login}/{t}/{id?}");


app.MapAreaControllerRoute("passenger",
    "Passenger",
    "Passenger/{controller=Login}/{action=Login}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();