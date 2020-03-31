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

        public HomeController(IUsuario Usuarios)
        {
            usuarios = Usuarios;
        }

        [Route("")]
        [Route("/Home")]
        public ViewResult Index()
        {
            var Usuarios = usuarios.obtenerTodosLosUsuarios();

            return View(Usuarios);
        }

        [Route("Home/Details/{id}")]
        public ViewResult Details(int id)
        {
            Usuario usuario = usuarios.obtenerUsuario(id);

            /*if(usuario == null)
            {
                Response.StatusCode = 404;
                return View("UsuarioNotFound", id);
            }*/

            return View(usuario);
        }

        [HttpGet]
        [Route("Home/Create")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario nuevoUsuario = usuarios.agregarUsuario(usuario);
                RedirectToAction("details", new { id = nuevoUsuario.id });
            }
            return View();
        }

        [HttpGet]
        [Route("Home/Edite/{id}")]
        public ViewResult Edit(int id)
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

        

    }
}
