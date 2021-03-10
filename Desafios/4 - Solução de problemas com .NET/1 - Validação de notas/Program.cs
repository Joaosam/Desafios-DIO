using System;
using System.Collections.Generic;

namespace programa_para_validacao_de_notas
{
    class Program
    {
        static void Main(string[] args)
        {
            double opcaoUsuario = 1;

            do
            {
                //Intanciando lista
                List<double> notasValidas = new List<double> {};
                double somaDasNotas = 0, media;

                while (notasValidas.Count != 2)
                {
                    double nota = double.Parse(Console.ReadLine());

                    if (nota < 0 || nota > 10)
                    {
                        Console.WriteLine("nota invalida");
                    }
                    else
                    {
                        notasValidas.Add(nota);
                    }
                }

                foreach (double notas in notasValidas)
                {
                    somaDasNotas += notas;
                }

                media = somaDasNotas / notasValidas.Count;
                Console.WriteLine("media = {0}", media.ToString("F2"));

                do
                {
                    Console.WriteLine("novo calculo (1-sim 2-nao)");
                    opcaoUsuario = double.Parse(Console.ReadLine());
                } while (opcaoUsuario != 1 && opcaoUsuario != 2);

            } while (opcaoUsuario != 2);
        }
    }
}