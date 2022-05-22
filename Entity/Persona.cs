using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoSangre { get; set; }
        public int Edad { get; set; }
       
        public List<Persona> Personas { get; set; }

        public Persona() { }

        public string Escribir()
        {
            return $"{Id};{Nombre};{TipoSangre}; {Edad}";
        }


    }
}
