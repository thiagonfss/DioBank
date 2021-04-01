using DioBank.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DioBank.Classes
{
    class Conta
    {
        //Atributos:
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private String Nome { get; set; }

        //Construtor: metodo chamado quando é criado o objeto e sempre tem o nome da classe.
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //Metodo que verifica se existe saldo suficiente para sacar.
        public bool Sacar(double valorSaque)
        {
            //
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
               return false;
            }

            this.Saldo -= valorSaque;

            //URL que explica essa interpolação
            //https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting
            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
            Console.WriteLine();
            Console.WriteLine("Deseja tentar um novo saque? (Y) Sim (N) Não");
            string redirecionar = Console.ReadLine();
            if (redirecionar.ToUpper() == "Y")

                return false;

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
        }

        public void AlterarCreditoConta(double credito, Conta contaAlterada)
        {
            
            this.Credito += credito;

            Console.WriteLine("Crédito atual da conta {0} é {1}", this.Nome, this.Credito);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            //Chama a validação do saque, se for válida debita da conta.
            if (this.Sacar(valorTransferencia))
            {
                //Realiza o credito na conta de destino.
                contaDestino.Depositar(valorTransferencia);
            }

        }

        //override vai sobreescrever o metodo toString do Object.
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }
    }
}
