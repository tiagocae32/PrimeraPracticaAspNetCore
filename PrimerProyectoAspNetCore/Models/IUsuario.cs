using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.Models
{
    public interface IUsuario
    {

        Usuario obtenerUsuario(int id);

        IEnumerable<Usuario> obtenerTodosLosUsuarios();

        Usuario agregarUsuario(Usuario usuario);

        Usuario editarUsuario(Usuario usuario);

        Usuario eliminarUsuario(int id);

    }
}
