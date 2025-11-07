using LoginEstudo.Dtos;

namespace LoginEstudo.Service;

public interface IUsuario
{
    void NovoUsuario(UsuarioLoginDTO usuarioDTO);
}