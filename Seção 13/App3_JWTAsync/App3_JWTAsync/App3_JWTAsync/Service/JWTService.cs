using System;
using System.Collections.Generic;
using System.Text;

namespace App3_JWTAsync.Service {
    public class JWTService {

        private static string BaseURL = "http://ws.spacedu.com.br/xf2018/apix";

        public static string GetToken(string nome, string password) {
            var URL = BaseURL + "/token";
            return "ok";
        }

        public static string Verificar(string token) {
            var URL = BaseURL + "/verify";
            return "ok";
        }
    }
}
