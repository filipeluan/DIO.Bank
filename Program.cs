using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        
        static void Main(string[] args)
        {

           string opcaoUsuario = MenuUsuario();
           while (opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    
               }

               opcaoUsuario = MenuUsuario();
           }

           Console.WriteLine("Obrigado por utilizar nossos serviços!");
           Console.ReadLine();
        }
        private static void Transferir()
        {
            Console.WriteLine("Transferência!");

            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());


            listaContas.First(list => list.acessoNumeroConta == indiceContaOrigem).Transferir(valorTransferencia, 
                                                                listaContas.First(destino => destino.acessoNumeroConta == indiceContaDestino));
        }

        private static void Depositar()
        {
            Console.WriteLine("Depósito!");

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas.First(list => list.acessoNumeroConta == indiceConta).Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Saque!");

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas.First(list => list.acessoNumeroConta == indiceConta).Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas:");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada. Por favor insira uma nova conta.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                var conta = listaContas[i];
                Console.Write("#{0} - ", conta.acessoNumeroConta);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta!");

            Console.Write("Digite 1 para conta Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito,
                                        numeroConta: numeroConta,
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static string MenuUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|   DIO Bank a seu dispor!  |");
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("| Informe a opção desejada: |");

            Console.WriteLine("|      1- Listar contas     |");
            Console.WriteLine("|    2- Inserir nova conta  |");
            Console.WriteLine("|       3- Transferir       |");
            Console.WriteLine("|          4- Sacar         |");
            Console.WriteLine("|        5- Depositar       |");
            Console.WriteLine("|      C- Limpar Tela       |");
            Console.WriteLine("|          X- Sair          |");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}