using GestaoProdutos.Persistence.Repositories;
using revisaoH1.Domain.Entities;
using System.Threading.Tasks;

namespace revisaoH1.Service
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            if (await _produtoRepository.BuscarPorNome(produto.Nome) != null)
                throw new Exception("Já existe um produto com esse nome.");
            if (await _produtoRepository.BuscarPorCodigoBarra(produto.CodigoBarra) != null)
                throw new Exception("Já existe um produto com esse código de barras.");

            await _produtoRepository.AdicionarProduto(produto);
        }

        public async Task BaixarEstoque(int produtoId, int quantidade)
        {
            await _produtoRepository.BaixarEstoque(produtoId, quantidade);
        }
    }
}
