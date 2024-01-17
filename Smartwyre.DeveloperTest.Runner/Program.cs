using Cocona;
using Serilog;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        try
        {
            Log.Information("Starting application");

            var builder = CoconaApp.CreateBuilder();

            // Add logging with Serilog
            builder.Host.UseSerilog();

            // Add dependencies
            builder.AddAppServices();

            var app = builder.Build();

            // Add commands
            app.AddAppCommands();

            app.Run();

            Log.Information("Stopping application");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
