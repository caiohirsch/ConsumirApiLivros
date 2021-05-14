using ConsumirApiLivros.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApiLivros
{
    public class ApiLivro
    {
        public string BaseUrl = "http://localhost/APILIVRO/";

        public async Task<List<Livro>> GetLivrosAsync()
        {

            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().GetAsync("api/livros");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Livro>>(dados);
            }

            return new List<Livro>();
        }

        public async Task<Livro> GetLivrosAsync(int id)
        {
            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().GetAsync("api/livros/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Livro>(dados);
            }

            return new Livro();
        }

        public async Task<bool> PostLivroAsync(Livro livro)
        {
            var jsonContent = JsonConvert.SerializeObject(livro);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().PostAsync("api/livros", contentString);

            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> PutLivroAsync(Livro livro)
        {
            var jsonContent = JsonConvert.SerializeObject(livro);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await HttpInstance.GetHttpClientInstance().PutAsync("api/livros", contentString);

            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
