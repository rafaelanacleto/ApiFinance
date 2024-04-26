namespace ApiFinance.Entities
{
    public class Despesas : Entity
    {
        public string? Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
