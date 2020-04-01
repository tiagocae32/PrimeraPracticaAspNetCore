using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.ViewModels
{
    public class CrearUsuarioModel
    {
       
        [Required]
        [MinLength(5, ErrorMessage = "Minimo 5 caracteres")]
        public string nombre { get; set; }

        [Required]
        //[RegularExpression(@"^[_a - z0 - 9 -] + (.[_a - z0 - 9 -] +) *@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$",ErrorMessage = "El formato de este email no es valido")]
        public string email { get; set; }

        [Required]
        [Range(18, 65, ErrorMessage = "La edad minima para registrarse es 18 y la edad maxima es 65 años")]
        public int edad { get; set; }
    }


}