using AutoMapper;
using LoginEstudo.Dtos;
using LoginEstudo.Entities;
using ISession = NHibernate.ISession;

namespace LoginEstudo.Service
{
    public class UsuarioService : IUsuario
    {
        private readonly IMapper _mapper;
        private readonly ISession _session;

        public UsuarioService(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _session = session;
        }

        public void NovoUsuario(UsuarioLoginDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Save(usuario);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}