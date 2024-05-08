using chatLab.Context;
using chatLab.Hubs;
using Microsoft.EntityFrameworkCore;

namespace chatLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<ChatContext>(op =>
            op.UseSqlServer(builder.Configuration.GetConnectionString("AliConnections")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapHub<ChatHub>("/chat");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=chat}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
