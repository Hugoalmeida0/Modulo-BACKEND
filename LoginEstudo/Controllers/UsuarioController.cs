using AutoMapper;
using LoginEstudo.Dtos;
using LoginEstudo.Entities;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Mapping;

namespace LoginEstudo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly NHibernate.ISession _session;

    public UsuarioController(IMapper mapper, NHibernate.ISession session)
    {
        _mapper = mapper;
        _session = session;
    }

    [HttpGet]
    public IList<Usuario> RecuperaLogins()
    {
        IQueryable<Usuario> query = _session.Query<Usuario>();
        IList<Usuario> ListagemDeUsuarios = query.ToList();

        return ListagemDeUsuarios;
    }

    [HttpPost]
    public void CadastroUsuario(UsuarioLoginDTO usuarioDTO)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDTO);
        ITransaction transaction = _session.BeginTransaction();

        try
        {
            _session.Save(usuario);
            transaction.Commit();
        }
        catch (System.Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}