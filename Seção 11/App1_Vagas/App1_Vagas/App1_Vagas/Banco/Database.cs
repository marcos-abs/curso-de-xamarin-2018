using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using App1_Vagas.Modelos;
using Xamarin.Forms;

namespace App1_Vagas.Banco {
    class Database {
        private SQLiteConnection _conexao;

        public Database() {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
        }

        public List<Vaga> Consultar() {
            return null;
        }

        public Vaga ObterVagaPorID(int id) {
            return null;
        }

        public void Cadastro(Vaga vaga) {

        }

        public void Alteracao(Vaga vaga) {

        }

        public void Exclusao(int id) {

        }
    }
}
