using System;
using System.Collections.Generic;

namespace API_VT.Utils
{
    public static class Feriados
    {
        private static Dictionary<string, int[]> _feriados = new Dictionary<string, int[]>
        {
            { "Confraternização Universal", new int[] {1, 1} },
            { "Tiradentes", new int[] {21, 4} },
            { "Dia do Trabalhador", new int[] {1, 5} },
            { "Dia da Pátria", new int[] {7, 9} },
            { "Nossa Senhora Aparecida", new int[] {12, 10} },
            { "Finados", new int[] {2, 11} },
            { "Proclamação da República", new int[] {15, 11} },
            { "Natal", new int[] {25, 12} }
        };

        public static List<DateTime> FeriadosMes(DateTime dataInicial, DateTime dataFinal)
        {
            DateTime diaAtual = dataInicial;
            List<DateTime> listaFeriados = new List<DateTime>();
            int numDias = dataFinal.Subtract(dataInicial).Days;
            for (int i = 1; i <= numDias; i++)
            {
                foreach (int[] feriado in _feriados.Values)
                {
                    if (diaAtual == new DateTime(diaAtual.Year, feriado[1], feriado[0]))
                    {
                        listaFeriados.Add(diaAtual);
                    }
                }
                diaAtual = diaAtual.AddDays(1);
            }
            return listaFeriados;
        }
    }
}
