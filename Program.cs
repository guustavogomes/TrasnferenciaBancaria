using System;
using System.Collections.Generic;
using banco.Enum;

namespace banco
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoEscolhida = EscolherOpcao();

            while (opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "4":
                        Depositar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoEscolhida = EscolherOpcao();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine("===========================================");

        }

        private static void Transferir()
        {
            Console.WriteLine("Informe o número da conta que gostaria de Origem?");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o número da conta que gostaria de Destino?");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual valor gostaria de transferir?");
            double valor = double.Parse(Console.ReadLine());

            ListContas[indiceContaOrigem].Transferir(valor, ListContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Informe o número da conta que gostaria de depositar?");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual valor gostaria de depositar?");
            double valor = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Depositar(valor);
        }

        private static void Sacar()
        {
            Console.WriteLine("Informe o número da conta que gostaria de sacar?");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual valor gostaria de sacar?");
            double valor = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Sacar(valor);
        }

        private static void InserirConta()
        {
            Console.WriteLine("**** Opção Inserir nova conta! ****");
            Console.WriteLine();

            Console.WriteLine("Qual tipo de conta é a sua? 1 - Fisica ou 2 - Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual nome do cliente?");
            string entradaNomeCliente = Console.ReadLine();

            Console.WriteLine("Qual o saldo inicial?");
            double entradaSaldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o crédito inicial?");
            double entradaCreditoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual o numero da agencia?");
            string entradaAgencia = Console.ReadLine();

            Console.WriteLine("Qual o numero da conta?");
            string entradaConta = Console.ReadLine();

            Console.WriteLine("Qual nome do banco?");
            string entradabanco = Console.ReadLine();

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        nome: entradaNomeCliente,
                                        saldo: entradaSaldoInicial,
                                        credito: entradaCreditoInicial,
                                        agencia: entradaAgencia,
                                        numeroConta: entradaConta,
                                        nomeBanco: entradabanco);

            ListContas.Add(novaConta);

        }

        private static void ListarContas()
        {
            if (ListContas.Count == 0)
            {
                Console.WriteLine("Não há nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < ListContas.Count; i++)
            {
                Conta conta = ListContas[i];
                Console.WriteLine("#{0}", i);
                Console.WriteLine(conta.ToString());
            }
        }

        private static string EscolherOpcao()
        {
            Console.WriteLine("Esse é o seu Menu de opções do Dio.Bank");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("1 - Para Listar uma conta.");
            Console.WriteLine("2 - Para inserir uma conta.");
            Console.WriteLine("3 - Para Sacar um valor");
            Console.WriteLine("4 - Para Depositar um valor");
            Console.WriteLine("5 - Para Transferir um valor entre contas");
            Console.WriteLine("6 - Para limpar a tela");
            Console.WriteLine("X - Para sair da aplicação");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
