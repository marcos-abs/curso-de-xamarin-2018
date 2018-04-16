using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Servico.Modelo
{
    public class Endereco {
        public int cep { get; set; }
        public int logradouro { get; set; }
        public int complemento { get; set; }
        public int bairro { get; set; }
        public int localidade { get; set; }
        public int uf { get; set; }
        public int unidade { get; set; }
        public int ibge { get; set; }
        public int gia { get; set; }
    }
}
