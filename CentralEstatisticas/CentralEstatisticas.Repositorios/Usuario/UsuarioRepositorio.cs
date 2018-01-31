using CentralEstatisticas.Entidades;
using CentralEstatisticas.Util.Conexao;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios.Usuario
{
    public class UsuarioRepositorio : AdoHelper
    {
        private const string SQL_LISTAR = @"
            SELECT 
	            id_usuario IdUsuario,
	            nome Nome,
	            login Login
            FROM 
	            dbo.usuario
            ";

        public UsuarioRepositorio() : base(TipoConexao.DbCentral)
        {
        }

        public IEnumerable<UsuarioEntidade> Listar()
        {
            return Query<UsuarioEntidade>(SQL_LISTAR, new Dapper.DynamicParameters());
        }
    }
}
