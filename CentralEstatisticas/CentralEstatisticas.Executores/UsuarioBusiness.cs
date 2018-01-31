using CentralEstatisticas.Entidades.Dto.Usuario;
using CentralEstatisticas.Repositorios.Usuario;
using System.Collections.Generic;
using System.Linq;

namespace CentralEstatisticas.Business
{
    public class UsuarioBusiness
    {
        public IEnumerable<UsuarioDto> Listar()
        {
            return new UsuarioRepositorio().Listar().Select(u => new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Login = u.Login
            });
        }
    }
}
