using AULA13.Domains;

namespace AULA13.Models.Domains
{
    public class Cobranca
    {
        public Cobranca()
        {

        }

        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public Cliente Cliente { get; set; }
    }
}