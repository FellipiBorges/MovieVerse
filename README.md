

   <h1>Movieverse API</h1>

   <p>Este é um projeto para interagir com a API do <strong>The Movie Database (TMDb)</strong>, onde foi implementada a autenticação para acessar dados da API. O projeto segue uma arquitetura em camadas para organizar o código de forma eficiente e modular.</p>

   <h2>Estrutura do Projeto</h2>
   <p>O projeto foi organizado utilizando a <strong>arquitetura em camadas</strong>, com as seguintes pastas principais:</p>
    <ul>
        <li><strong>Model</strong>: Responsável por armazenar as classes que representam o retorno dos dados da API. Estas classes são utilizadas para deserializar o JSON retornado pela API para objetos C#.</li>
        <li><strong>Services</strong>: Contém a lógica de autenticação e interação com a API. Aqui, o serviço de <strong>LoginService</strong> foi criado para realizar o processo de autenticação usando um token de acesso (Bearer Token).</li>
    </ul>

   <h2>Funcionalidades</h2>

   <h3>1. Modelo (Model)</h3>
    <p>Foi criada a pasta <strong>Model</strong> para armazenar as classes que representam a estrutura do JSON retornado pela API do TMDb. Essas classes são responsáveis por mapear os dados da resposta da API para objetos C#.</p>
    <p>Exemplo de uma classe de modelo:</p>

   <pre>
        <code>
        public class LoginResponseModel
        {
            public bool Success { get; set; }
            public int StatusCode { get; set; }
            public string StatusMessage { get; set; }
            
            public LoginResponseModel(bool success, int statusCode, string statusMessage)
            {
                Success = success;
                StatusCode = statusCode;
                StatusMessage = statusMessage;
            }
        }
        </code>
    </pre>

   <h3>2. Serviço (Services)</h3>
    <p>O <strong>LoginService</strong> foi criado para lidar com a autenticação da API. Este serviço realiza a chamada HTTP para a API e tenta obter uma resposta autenticada utilizando um token de autenticação.</p>
    <p>Exemplo de como a autenticação é realizada:</p>

   <pre>
        <code>
        public async Task LoginAsync()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/authentication");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer <your_bearer_token>");
            var response = await client.GetAsync(request);
            
            Console.WriteLine("{0}", response.Content);
        }
        </code>
    </pre>

   <h3>3. Arquitetura em Camadas</h3>
    <p>O projeto foi estruturado para seguir a arquitetura em camadas, separando a lógica de negócios (serviços) e as representações de dados (modelos), o que torna o código mais modular, fácil de manter e escalável.</p>
    <p>A organização do código segue um padrão onde:</p>
    <ul>
        <li><strong>Model</strong> contém as classes de dados .</li>
        <li><strong>Services</strong> contém a lógica de negócios (como autenticação e chamadas à API).</li>
    </ul>

   <h2>Como Rodar o Projeto</h2>
    <ol>
        <li>Clone o repositório para sua máquina local:
            <pre><code>git clone <url_do_repositorio></code></pre>
        </li>
        <li>Navegue até o diretório do projeto:
            <pre><code>cd movieverse-api</code></pre>
        </li>
        <li>Instale as dependências (caso esteja utilizando o .NET, por exemplo):
            <pre><code>dotnet restore</code></pre>
        </li>
        <li>Execute o projeto:
            <pre><code>dotnet run</code></pre>
        </li>
        <li>Certe-se de que o arquivo <code>development.json</code> (ou outro arquivo de configuração) contendo as credenciais de autenticação (Bearer Token) esteja corretamente configurado.</li>
    </ol>

   <h2>Considerações Finais</h2>
    <p>Este projeto é um exemplo simples de como organizar um código em uma arquitetura em camadas, tratando a interação com uma API externa e utilizando autenticação baseada em um token. Ele pode ser facilmente expandido para incluir outras funcionalidades da API do TMDb, como busca de filmes, listagem de filmes populares e muito mais.</p>



<p align="center">
<img loading="lazy" src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/>
</p>


