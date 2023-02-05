using Microsoft.OpenApi.Models;
using VeloxDB.AspNet.Extensions;
using vabApp.Shared;
using Microsoft.AspNetCore.Mvc.Formatters;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews().AddJsonOptions((options) =>
        {
            options.JsonSerializerOptions.Converters.Add(new LongToStringConverter());
        });

		builder.Services.AddControllers(options =>
		{
			options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
		});

		builder.Services.AddRazorPages();
        builder.Services.AddSwaggerGen(options => options.MapType<long>(() => new OpenApiSchema { Type = "string" }));
        builder.Services.AddVeloxDBConnectionProvider("address=localhost:7568;");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}