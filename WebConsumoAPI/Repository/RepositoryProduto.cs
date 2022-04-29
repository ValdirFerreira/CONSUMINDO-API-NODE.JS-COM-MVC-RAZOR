using Newtonsoft.Json;
using System.Text;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Repository
{
    public class RepositoryProduto : IProduto
    {

        private readonly string uprApi = "http://localhost:4200/";

        public Produto Create(Produto produto)
        {
            var produtoCriado = new Produto();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Create", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtoCriado;
        }

        public Produto Update(Produto produto)
        {
            var produtoCriado = new Produto();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtoCriado;
        }

        public Produto Delete(int Codigo)
        {
            var produtoCriado = new Produto();
            produtoCriado.Codigo = Codigo;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Delete", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtoCriado;
        }

        public Produto GetOne(int Codigo)
        {
            var produtoCriado = new Produto();
            produtoCriado.Codigo = Codigo;
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "GetOne", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtoCriado;
        }

        public List<Produto> List()
        {
            var retorno = new List<Produto>();

            try
            {
                using (var cliente = new HttpClient())
                {
                    var resposta = cliente.GetStringAsync(uprApi + "List");
                    resposta.Wait();
                    retorno = JsonConvert.DeserializeObject<Produto[]>(resposta.Result).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }


    }
}
