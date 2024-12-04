namespace revisaoH1.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CodigoBarra { get; private set; }
        public decimal Valor { get; private set; }
        public int Estoque { get; private set; }

        public Produto(int id, string nome, string descricao, string codigoBarra, decimal valor, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(codigoBarra)) throw new ArgumentException("O código de barras é obrigatório.");
            if (valor < 0) throw new ArgumentException("O valor não pode ser negativo.");
            if (estoque < 0) throw new ArgumentException("O estoque não pode ser negativo.");

            Id = id;
            Nome = nome;
            Descricao = descricao;
            CodigoBarra = codigoBarra;
            Valor = valor;
            Estoque = estoque;
        }
        public void BaixarEstoque(int quantidade)
        {
            if (quantidade <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
            if (quantidade > Estoque) throw new InvalidOperationException("Estoque insuficiente.");

            Estoque -= quantidade;
        }
    }
}
