using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.View.Util {
    public class LabelPontuacaoConverter : IValueConverter {

        // View > ViewModel (informação)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            //short Pontuacao = short.Parse(value as string); - tipo não é short e sim byte.
            //return "Pontuação: " + Pontuacao;
            if((byte) value == 0) {
                return "Palavra";
            } else {
                return "Palavra - Pontuação: " + value;
            }
        }

        // ViewModel > View (informação)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
