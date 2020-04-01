using Microsoft.AspNetCore.Mvc;
using PrimerProyectoAspNetCore.Models;
using PrimerProyectoAspNetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.Controllers
{
    public class HomeController : Controller
    {

        private IUsuario usuarios;
        private DBUsuarioContext context;

        public HomeController(IUsuario Usuarios,DBUsuarioContext Context)
        {
            usuarios = Usuarios;
            context = Context;
        }

        [Route("")]
        [Route("Home")]
        public ViewResult Index()
        {
            var Usuarios = usuarios.obtenerTodosLosUsuarios();

            return View(Usuarios);
        }

        [Route("Home/Details/{id}")]
        public ViewResult Details(int id)
        {
            Usuario usuario = usuarios.obtenerUsuario(id);

            if(usuario == null)
            {
                Response.StatusCode = 404;
                return View("UsuarioNotFound", id);
            }

            return View(usuario);
        }

        [Route("Home/Create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CrearUsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario nuevoUsuario = new Usuario()
                {
                    nombre = usuario.nombre,
                    email = usuario.email,
                    edad = usuario.edad
                };
                usuarios.agregarUsuario(nuevoUsuario);
                return RedirectToAction("Details", new { id = nuevoUsuario.id });
            }
            return View();
        }

        [HttpGet]
        [Route("Home/Edite/{id}")]
        public ViewResult Edite(int id)
        {
            Usuario usuario = usuarios.obtenerUsuario(id);

            EditarUsuarioModel infoUsuario = new EditarUsuarioModel()
            {
                id = usuario.id,
                nombre = usuario.nombre,
                email = usuario.email,
                edad = usuario.edad
            };

            return View(infoUsuario);
        }

        [HttpPost]
        public IActionResult Edite(EditarUsuarioModel model)
        {

            if (ModelState.IsValid)
            {
                Usuario usuario = usuarios.obtenerUsuario(model.id);

                usuario.nombre = model.nombre;
                usuario.email = model.email;
                usuario.edad = usuario.edad;

                Usuario usuarioModificado = usuarios.editarUsuario(usuario);

                return RedirectToAction("Index");
            }

            return View();
        }

        //utilizando async y await
        public async Task<IActionResult>Delete(int id)
        {
            var usuario = await context.dataUsuarios.FindAsync(id);

            context.dataUsuarios.Remove(usuario);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
