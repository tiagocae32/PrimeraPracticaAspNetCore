using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.Models
{
    public class Usuario
    {

        public int id { get; set; }

        public string nombre { get; set; }

        public string email { get; set; }

        public int edad { get; set; }
    }
}
