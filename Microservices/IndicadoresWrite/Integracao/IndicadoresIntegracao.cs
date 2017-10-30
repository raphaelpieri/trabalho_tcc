using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using IndicadoresWrite.Domain;
using Newtonsoft.Json;

namespace IndicadoresWrite.Integracao
{
    public class IndicadoresIntegracao
    {
        public async void EnviarIndicador(Indicador indicador)
        {
            using (var client = new HttpClient())
            {
                string address = @"http://localhost:5002/api/indicador/";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var body = JsonConvert.SerializeObject(indicador);
                var response =
                    await client.PostAsync(address, new StringContent(body, Encoding.UTF8, "application/json"));
            }
            
        }
    }
}