using revisaoH1.Domain.Entities;

namespace revisaoH1.Data.Repositories
{
    public interface IProdutoRepository
    {
        Task AdicionarProduto(Produto produto);
        Task<Produto> BuscarPorCodigoBarra(string codigoBarra);
        Task<Produto> BuscarPorNome(string nome);
        Task<List<Produto>> ListarTodos();
        Task BaixarEstoque(int produtoId, int quantidade);
    }
}
