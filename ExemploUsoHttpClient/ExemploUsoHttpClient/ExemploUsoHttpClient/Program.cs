using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

void ExemploGet()
{
    Console.WriteLine("Exemplo utilização http client - verbo GET - bored api");

    using var client = new HttpClient();

    var request = new HttpRequestMessage(
        HttpMethod.Get,
        "http://www.boredapi.com/api/activity/?participants=1"
    );

    Console.WriteLine("-- Requisição get");

    using var response = client.Send(request);

    Console.WriteLine($"Retorno: ");
    Console.WriteLine($"Status Code: {response.StatusCode}");
    Console.WriteLine($"Corpo: {response.Content.ReadAsStringAsync().Result}");
    Console.WriteLine($"Headers: {string.Join(',', response.Headers.Select(h => $"{h.Key}={string.Join(',', h.Value)}"))}");
}

void ExemploPost()
{
    Console.WriteLine("Exemplo utilização http client - verbo POST - sentim api");

    using var client = new HttpClient();

    var json = JsonSerializer.Serialize(new
    {
        text = "I love so much programming"
    });

    
    var request = new HttpRequestMessage(HttpMethod.Post, "https://sentim-api.herokuapp.com/api/v1/")
    {
        Headers = {
            { "Accept", "application/json" }
        },
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };

    using var response = client.Send(request);

    Console.WriteLine($"Retorno: ");
    Console.WriteLine($"Status Code: {response.StatusCode}");
    Console.WriteLine($"Corpo: {response.Content.ReadAsStringAsync().Result}");
    Console.WriteLine($"Headers: {string.Join(',', response.Headers.Select(h => $"{h.Key}={string.Join(',', h.Value)}"))}");
}

ExemploGet();
ExemploPost();