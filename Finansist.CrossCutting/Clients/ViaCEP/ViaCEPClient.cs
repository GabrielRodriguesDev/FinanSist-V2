using Finansist.Domain.Commands;
using Finansist.Domain.Interfaces.CrossCutting.Interfaces.Clients;
using Finansist.Domain.Models.Clients;
using Newtonsoft.Json;


namespace Finansist.CrossCutting.Clients.ViaCEP
{
    public class ViaCEPClient : IViaCEPClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private String baseUrl = Environment.GetEnvironmentVariable("BaseViaCEPUrl") ?? "";

        public async Task<GenericCommandResult> GetEnderecoAsync(string cep)
        {
            var response = await HttpClient.GetAsync(baseUrl+$"ws/{cep}/json");

            var responseContent = await response.Content.ReadAsStringAsync();
            if(!String.IsNullOrEmpty(responseContent) && response.IsSuccessStatusCode)
            {
                var modeldb = JsonConvert.DeserializeObject<EnderecoModel>(responseContent);
                return new GenericCommandResult(true, "Pedido no pagarme criado com sucesso!", modeldb!);
            }
            return new GenericCommandResult(false, "Deu erro");
        }
    }
}
