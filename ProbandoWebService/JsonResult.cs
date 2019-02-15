using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbandoWebService
{
    class JsonResult
    {
        public string idPersona { get; set; }
        public string docPersona { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string genero { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string pass { get; set; }
        public string sucursal_id { get; set; }
        public string estado { get; set; }
        public string rol_id { get; set; }                
    }
}
