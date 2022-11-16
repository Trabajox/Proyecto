using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorasi.Models
{
    public class Usuarios
    {
        public string Nombres { set; get; }
        public string Correo { set; get; }
        public string Clave { set; get; }
        public Rol IdRol { set; get; }
        
    }
}