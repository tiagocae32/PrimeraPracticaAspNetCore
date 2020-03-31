using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.Models
{
    public class SqlUsuarioRepositorio : IUsuario
    {

        private readonly DBUsuarioContext context;

        public SqlUsuarioRepositorio(DBUsuarioContext Context)
        {
            context = Context;
        }


        public Usuario agregarUsuario(Usuario usuario)
        {
            context.dataUsuarios.Add(usuario);
            context.SaveChanges();
            return usuario;
        }

        public Usuario editarUsuario(Usuario usuarioEdit)
        {
            var Usuario = context.dataUsuarios.Attach(usuarioEdit);
            Usuario.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return usuarioEdit;
        }

        public Usuario eliminarUsuario(int id)
        {
            Usuario usuario = context.dataUsuarios.Find(id);

            if(usuario != null)
            {
                context.dataUsuarios.Remove(usuario);
                context.SaveChanges();
            }

            return usuario;
        }

        public IEnumerable<Usuario> obtenerTodosLosUsuarios()
        {
            return context.dataUsuarios;
        }

        public Usuario obtenerUsuario(int id)
        {
            return context.dataUsuarios.Find(id);
        }
    }
}
