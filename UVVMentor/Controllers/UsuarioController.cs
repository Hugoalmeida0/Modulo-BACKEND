using Microsoft.AspNetCore.Mvc;
using NHibernate;
using UVVMentor.Entitys;
using UVVMentor.Infra;

namespace UVVMentor.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult NovoUsuario([FromBody] Usuario usuario)
    {
        using var session = HibernateUtil.GetSession();
        ITransaction transaction = null;
        try
        {
            transaction = session.BeginTransaction();
            session.Save(usuario);
            transaction.Commit();
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            transaction?.Rollback();
            return StatusCode(500, ex.Message);
        }
    }
}