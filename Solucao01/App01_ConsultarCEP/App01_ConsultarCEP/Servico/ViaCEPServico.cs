using System;
using System.Collections.Generic;
using System.Text;
using System.Net; // para uso do WebClient.
using App01_ConsultarCEP.Servico.Modelo; // para retornar um objeto endereço.
using Newtonsoft.Json; // deserializador do JSON.

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep) {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            
            string conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;
        }
    }
}
