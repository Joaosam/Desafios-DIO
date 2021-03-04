/**********************************************************************************************
 * Transações Bancárias  
 ********************************
 *
 *      Programa com intuito de desenvolver mais as caracteristicas da programação orientada a objetos.
 *
 **********************************************************************************************/

using System;
using System.Collections.Generic;

namespace DIO.BANK
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>(); //Criando Lista
        static void Main(string[] args)
        {           
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        SacarConta();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;                   

                    default:
                        throw new ArgumentOutOfRangeException("Opção inexistente!");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }  
             Console.WriteLine("\nObrigado por utilizar nossos serviços. Joaosan ©");
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            //Método Transferir espera como parâmetro o valor de transferencia e a conta de destino
            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
            

        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void SacarConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas!");
            if (listaContas.Count == 0) 
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }

            for (int i=0; i<listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta!\n");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            // Instanciando objeto novaConta da classe Conta
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            //Adiciono conta em minha coleção listaContas
            listaContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nDIO Bank a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:\n");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();            
            return opcaoUsuario;
        }
    }
}
