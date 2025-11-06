
using Autoplay_API.Models;
using Autoplay_API.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ISession = NHibernate.ISession;
using NHibernate;

namespace Autoplay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISession _session;
        public ProdutoController(IMapper imapper, ISession session)
        {
            _mapper = imapper;
            _session = session;
        }

        [HttpGet]
        public IList<Produto> RecuperaProdutos()
        {
            IQueryable<Produto> query = _session.Query<Produto>();
            IList<Produto> produtos = query.ToList();
            return produtos;
        }
        [HttpPost]
        public void InserirProdutos(ProdutoRequestDTO produtoRequest)
        {
            var produto = _mapper.Map<Produto>(produtoRequest);
            ITransaction transaction = _session.BeginTransaction();
            try
            {
                _session.Save(produto);
                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        [HttpPut("{id}")]
        public void AlterarProduto(int id, [FromQuery] ProdutoRequestDTO produtoRequest)
        {
            ITransaction transaction = _session.BeginTransaction();

            try
            {
                Produto produto = _session.Get<Produto>(id);
                produto.Preco = produtoRequest.Preco;
                produto.Nome = produtoRequest.Nome;

                _session.Update(produto);
                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }

        }
        [HttpDelete("{id}")]
        public void DeletarProduto(int id)
        {
            ITransaction transaction = _session.BeginTransaction();

            try
            {
                Produto produto = _session.Get<Produto>(id);
                _session.Delete(produto);
                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }

        }
        [HttpGet("{id}")]
        public Produto RecuperarProduto(int id)
        {
            Produto produto = _session.Get<Produto>(id);
            return produto;
        }
    }
}