using System;
using System.Collections.Generic;
using System.Text;

using System.Net;       // para utilizar verbo POST para requisições para WEB 1de2.
using System.Net.Http;  // para utilizar verbo POST para requisições para WEB 2de2.
using App1_NossoChat.Model; // para utilizar a classe "Usuario" do projeto.

namespace App1_NossoChat.Service {
    public class ServiceWS {
        private static string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";
        public static Usuario GetUsuario(Usuario usuario) {
            var URL = EnderecoBase + "/usuario";

            // Exemplo de outra forma de fazer a mesma Query abaixo:
            //StringContent param = new StringContent(string.Format("?nome={0}&password={1}", usuario.nome, usuario.password));

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", usuario.nome),
                new KeyValuePair<string, string>("password", usuario.password)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if(resposta.StatusCode == HttpStatusCode.OK) {
                //TODO Deserializar, retornar no metodo e salvar como login.
            }
            return null;
        }
    }
}
