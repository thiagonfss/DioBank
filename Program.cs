using DioBank.Classes;
using DioBank.Enum;
using System;
using System.Collections.Generic;

namespace DioBank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
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
                        InserirConta();
                        break;
                    case "3":
                        Tranferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "A":

                        alterarCredito();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void alterarCredito()
        {
            Console.WriteLine("Digite a conta que deseja alterar o credito");
            int indiceConta = int.Parse(Console.ReadLine());

            if (listaContas[indiceConta] != null)
            {
                Console.WriteLine("Digite o valor que deseja alterar para a conta");
                double valorCredito = int.Parse(Console.ReadLine());

                listaContas[indiceConta].AlterarCreditoConta(valorCredito, listaContas[indiceConta]);
            }
        }

        private static void Tranferir()
        {
            Console.WriteLine("Digite o número da conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido");
            double valorTransferencia = int.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("              Inserir nova conta");
            Console.WriteLine("----------------------------------------------");
           
            Console.WriteLine("Digite 1 para conta física ou 2 para Jurídica.");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Digite o nome do cliente:");
            string entradaNome = Console.ReadLine();
            
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listaContas.Add(novaConta);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void ListarContas()
        {
            Console.WriteLine("              Listar contas");
            Console.WriteLine("----------------------------------------------");
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine("Deseja ser abrir uma nova conta? (Y) Sim (N) Não");
                string redirecionar = Console.ReadLine();
                if (redirecionar.ToUpper() == "Y")
                    InserirConta();
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", (i));
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            string[] menus =
            {
                "",
                "DIO Bank a seu dispor!!!",
                "Informe a oção desejada:",
                "1- Listar contas",
                "2- Abrir uma nova conta",
                "3- Transferir",
                "4- Sacar",
                "5- Depositar",
                "A- Alterar saldo da conta",
                "C- Limpar Tela",
                "X- Sair",
                ""
            };

            foreach (string menu in menus)
            {
                Console.WriteLine(menu);
            }

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
