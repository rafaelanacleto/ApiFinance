using ApiFinance.Validation;

namespace ApiFinance.Entities
{
    public sealed class Categoria : Entity
    {
        public Categoria()
        { }

        public string? Nome { get; private set; }
        public string? Cor { get; private set; }

        public Categoria(int id, string nome, string cor)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(nome, cor);
        }

        public void Update(string nome, string cor)
        {
            ValidateDomain(nome, cor);
        }

        private void ValidateDomain(string nome, string cor)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3,
               "Nome inválido");
            Nome = nome;

            DomainExceptionValidation.When(string.IsNullOrEmpty(cor),
              "Nome do ícone é obrigatório");
            DomainExceptionValidation.When(cor.Length < 3,
              "Nome do ícone inválido");
            Cor = cor;
        }

    }
}
