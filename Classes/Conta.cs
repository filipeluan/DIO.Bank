namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private int numeroConta {get; set;}
        private string Nome {get; set;}

        
        public Conta(TipoConta tipoConta, double saldo, double credito, int numeroConta, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.numeroConta = numeroConta;
            this.Nome = nome;
        }
        public int acessoNumeroConta {
             get => numeroConta; 
             set{
                 numeroConta = value;
             }
        } 

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("O Saldo atual da conta de {0} é: R${1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("O Saldo atual da conta de {0} é: R${1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta -> " + this.TipoConta + " | ";
            retorno += "Número da conta: " + this.numeroConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo = R$" + this.Saldo + " | ";
            retorno += "Crédito = R$" + this.Credito;
            return retorno;
        }
    }
}