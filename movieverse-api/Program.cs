using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using movieverse_api.Services;

public class Program
{
    public static void Main(string[] args)
    {
        // Cria o builder e carrega as configurações
        var builder = WebApplication.CreateBuilder(args);

        // Carrega o arquivo appsettings.Development.json
        builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

        // Adiciona LoginService ao container de injeção de dependência
        builder.Services.AddTransient<LoginService>();

        var app = builder.Build();

        // Resolve o LoginService e chama o método LoginAsync
        using (var scope = app.Services.CreateScope())
        {
            var loginService = scope.ServiceProvider.GetRequiredService<LoginService>();
            loginService.LoginAsync().Wait(); // Aguarda a execução
        }

        app.Run();
    }
}
