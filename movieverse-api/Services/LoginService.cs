using movieverse_api.Models;
using RestSharp;
using System.Text.Json;



namespace movieverse_api.Services
{
    public class LoginService
    {   
        private readonly IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task LoginAsync()
        {
            var baseUrl = _configuration[$"Authentication:ApiBaseUrl"];

            var bearerToken = _configuration["Authentication:BearerToken"];

            var options = new RestClientOptions(baseUrl);

            var client = new RestClient(options);

            var request = new RestRequest("");

            request.AddHeader("accept", "application/json");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            try
            {
                var response = await client.GetAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    try
                    {
                        var loginResponse = JsonSerializer.Deserialize<LoginResponseModel>(response.Content);

                        if (loginResponse != null)
                        {
                            if (loginResponse.Success = true)
                            {
                                Console.WriteLine($"    __         __\r\n   /.-'       `-.\\\r\n  //             \\\\\r\n /___AUTENTICADO___\\\r\n/o.-==-. .-. .-==-.o\\\r\n||      )) ((      ||\r\n \\\\____//   \\\\____//   \r\n  `-==-'     `-==-'");
                            }
                            else
                            {
                                Console.WriteLine("Falha na autenticação, verifique sua CHAVE DE AUTORIZAÇÃO");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Falha ao desserializar a resposta.");
                        }
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine("Erro ao processar o JSON:");
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Erro na requisição:");
                    Console.WriteLine(response.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
