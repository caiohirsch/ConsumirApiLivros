using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumirApiLivros.Models
{
    public class Livro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        
        public void TestarGetLivros()
        {
            List<Livro> aux = new List<Livro>();

            ApiLivro api = new ApiLivro();
            var livrosTask = api.GetLivrosAsync();

            livrosTask.ContinueWith(task =>
            {
                var livros = task.Result;
                foreach (var livro in livros) aux.Add(livro);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public void TestarGetLivros(int id)
        {
            List<Livro> aux = new List<Livro>();

            ApiLivro api = new ApiLivro();
            var livrosTask = api.GetLivrosAsync(id);

            livrosTask.ContinueWith(task =>
            {
                var livro = task.Result;                
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public void TestarPostLivro()
        {
            Livro livro = new Livro() { ID = 6, Autor = "Cruzeirão Cabuloso", Titulo = "Cruzeiro Maior campeão do século XX" };
            ApiLivro apiLivro = new ApiLivro();
            var aux = apiLivro.PostLivroAsync(livro);
        }

        public void TestarPutLivro()
        {
            Livro livro = new Livro() { ID = 1, Autor = "Cruzeirão Cabuloso", Titulo = "Cruzeiro Maior campeão do século XX" };
            ApiLivro apiLivro = new ApiLivro();
            var aux = apiLivro.PutLivroAsync(livro);
        }
    }
}
