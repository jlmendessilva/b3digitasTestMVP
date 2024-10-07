using Newtonsoft.Json;
using System.Text;


namespace b3digitas.WS.Extension
{
    public class Api
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private string apiUrl = "https://localhost:7003/api/order/PostBulk";
        public async Task SendMessageToApi(string message)
        {
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Dados enviados com sucesso para a API.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar dados para a API: {ex.Message}");
            }
        }

        public async Task SendToApi(List<object> bidsList, List<object> asksList)
        {
            try
            {
                if (bidsList.Count == 0 || asksList.Count == 0)
                    Console.WriteLine($"Lista vazia");

                var apiClient = new Api();

                Console.WriteLine($"Enviando lista bis com {bidsList.Count} order");
                await apiClient.SendMessageToApi(JsonConvert.SerializeObject(bidsList));
                Console.WriteLine($"Enviando lista aks com {asksList.Count} order");
                await apiClient.SendMessageToApi(JsonConvert.SerializeObject(asksList));
                Console.WriteLine($"Enviando listas enviada a API");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
    }
}
