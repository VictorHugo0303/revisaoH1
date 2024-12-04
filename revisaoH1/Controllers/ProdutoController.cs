using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using revisaoH1.Domain.Entities;
using revisaoH1.Service;

namespace revisaoH1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
        {
            await _produtoService.AdicionarProduto(produto);
            return Ok("Produto adicionado com sucesso.");
        }

        [HttpGet("{codigoBarra}")]
        public async Task<IActionResult> BuscarPorCodigo(string codigoBarra)
        {
            var produto = await _produtoService.BuscarPorCodigo(codigoBarra);
            return produto != null ? Ok(produto) : NotFound("Produto não encontrado.");
        }

        [HttpPost("{id}/baixar-estoque")]
        public async Task<IActionResult> BaixarEstoque(int id, [FromQuery] int quantidade)
        {
            await _produtoService.BaixarEstoque(id, quantidade);
            return Ok("Estoque atualizado.");
        }
    }
}
