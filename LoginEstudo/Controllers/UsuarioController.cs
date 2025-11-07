using AutoMapper;
using LoginEstudo.Dtos;
using LoginEstudo.Entities;
using LoginEstudo.Service;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Mapping;

namespace LoginEstudo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuario _usuarioService;

    public UsuarioController(IUsuario usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public IActionResult CadastroUsuario([FromBody] UsuarioLoginDTO usuarioDTO)
    {
        _usuarioService.NovoUsuario(usuarioDTO);
        return Ok("Usuário cadastrado com sucesso!");
    }
}