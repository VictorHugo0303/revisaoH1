using revisaoH1.Data.Context;
using revisaoH1.Data.Repositories;
using revisaoH1.Domain.Entities;

namespace revisaoH1.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> BuscarPorCodigoBarra(string codigoBarra)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.CodigoBarra == codigoBarra);
        }

        public async Task<Produto> BuscarPorNome(string nome)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Nome == nome);
        }

        public async Task<List<Produto>> ListarTodos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task BaixarEstoque(int produtoId, int quantidade)
        {
            var produto = await _context.Produtos.FindAsync(produtoId);
            if (produto == null) throw new KeyNotFoundException("Produto não encontrado.");
            if (quantidade > produto.Estoque) throw new InvalidOperationException("Estoque insuficiente.");

            produto.BaixarEstoque(quantidade);
            await _context.SaveChangesAsync();
        }
    }
}
