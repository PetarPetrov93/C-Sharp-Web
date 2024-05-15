using HouseRentingSystem_Workshop.ModelBinders;

namespace HouseRentingSystem_Workshop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);

            builder.Services.AddControllersWithViews(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            });

            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}
