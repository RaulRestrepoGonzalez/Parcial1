using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class PersonaRepository
    {

        string ruta = "Personas.txt";

        public void Guardar(Persona persona)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine(persona.Escribir());
            escritor.Close();
            file.Close();
        }

        public List<Persona> Consultar()
        {
            List<Persona> persona = new List<Persona>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            string linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                Persona personas = MapearPersona(linea);
                persona.Add(personas);
            }
            lector.Close();
            file.Close();
            return persona;
        }

        public void Eliminar(Persona persona)
        {
            //persona.Remove(persona);
        }

        private static Persona MapearPersona(string linea)
        {
            string[] datosPersona = linea.Split(';');
            Persona persona = new Persona();
            persona.Id = int.Parse(datosPersona[0]);
            persona.Nombre = datosPersona[1];
            persona.TipoSangre = datosPersona[2];
            persona.Edad = int.Parse(datosPersona[3]);
            return persona;
        }

    }
}
