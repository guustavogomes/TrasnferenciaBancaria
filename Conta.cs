using System;
using banco.Enum;
namespace banco
{
    public class Conta
    {
        private string nome { get; set; }
        private TipoConta tipoConta { get; set; }
        private double saldo { get; set; }
        private double credito { get; set; }
        private string agencia { get; set; }
        private string numeroConta { get; set; }
        private string nomeBanco { get; set; }

        public Conta(string nome, TipoConta tipoConta, double saldo, double credito, string agencia, string numeroConta, string nomeBanco)
        {
            this.nome = nome;
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.agencia = agencia;
            this.numeroConta = numeroConta;
            this.nomeBanco = nomeBanco;

        }

        public bool Sacar(double valor)
        {
            if ((this.saldo - valor) < (this.credito * -1))
            {
                Console.WriteLine("Valor sacado é maior que o crédito disponível!");
                return false;
            }


            this.saldo -= valor;
            Console.WriteLine("Saldo da conta de {0} é: {1}", this.nome, this.saldo);

            return true;
        }

        public void Depositar(double valor)
        {
            this.saldo += valor;
            Console.WriteLine("Saldo da conta de {0} é: {1}", this.nome, this.saldo);
        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if (this.Sacar(valor))
            {
                contaDestino.Depositar(valor);

            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome:-> " + this.nome + "\n";
            retorno += "Tipo Conta:-> " + this.tipoConta + "\n"; ;
            retorno += "Saldo:-> " + this.saldo + "\n"; ;
            retorno += "Credito:-> " + this.credito + "\n"; ;
            retorno += "Agencia:-> " + this.agencia + "\n"; ;
            retorno += "Numero Conta:-> " + this.numeroConta + "\n"; ;
            retorno += "Banco:-> " + this.nomeBanco;
            return retorno;
        }
    }
}