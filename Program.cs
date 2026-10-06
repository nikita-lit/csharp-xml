using System.Text;
using NuLua;
using NuLua.Luau;

namespace csharp_xml;

public class Program
{
    public static LuauState Luau { get; set; }
    
    public static readonly StringBuilder LuauOutput = new();
    
    public static void Test()
    {
        Luau = LuauState.Create();
        Luau.OpenLibraries();

        var file = File.ReadAllText("Luau/test.luau");
        var results = Luau.DoString(file);
        
        foreach (var result in results)
            Console.WriteLine(result);
        
        Luau.RegisterFunction("print", (state, args) =>
        {
            try
            {
                var line = args[0].Read<string>();
                LuauOutput.AppendLine(line);
                Console.WriteLine(line);
            }
            catch (Exception e)
            {
                LuauOutput.AppendLine(e.ToString());
                Console.WriteLine(e.ToString());
            }


            return 0;
        });
    }
    
    public static void Main(string[] args)
    {
        Thread workerThread = new Thread(() => Test())
        {
            Name = "CustomWorker",
            IsBackground = true
        };
        
        workerThread.Start();
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
