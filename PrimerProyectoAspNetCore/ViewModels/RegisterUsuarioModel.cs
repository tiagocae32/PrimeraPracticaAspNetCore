using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.ViewModels
{
    public class RegisterUsuarioModel
    {
        [Required]
        [EmailAddress]
        [Remote(action:"chequearEmail", controller:"Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Las dos contraseñas deben coincidir")]
        public string ConfirmPassword { get; set; }

    }
}
