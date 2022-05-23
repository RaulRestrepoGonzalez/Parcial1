using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace Parcial1
{
    public class Program
    {
        PersonaService personaService = new PersonaService();
        

        static void Main(string[] args)
        {

            Console.WriteLine("Digite la opcion: ");
            Console.WriteLine("1.Guardar");
            Console.WriteLine("2.Eliminar");
            Console.WriteLine("3.Consultar");
            Console.WriteLine("4.Modificar");
            Console.WriteLine("5.Salir");
            Console.Read();

            switch (Console.Read())
            {
                case 1:
                    GuardarPersona();
                    break;
                case 2:
                    EliminarPersonba();
                    break;
                case 3:
                    ConsultarPersona();
                    break;
                case 4:
                    ModificarPersona();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        }

        public void GuardarPersona()
        {
            Console.Clear();
            Persona personas = new Persona();

            Console.WriteLine("Digite el ID: ");
            personas.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite el nombre: ");
            personas.Nombre = Console.ReadLine();
            Console.WriteLine("Digite el tipo de sangre: ");
            personas.TipoSangre = Console.ReadLine();
            Console.WriteLine("Digite la edad: ");
            personas.Edad = int.Parse(Console.ReadLine());

            string mensaje = personaService.Guardar(personas);
            return personas;
        }

        public void EliminarPersonba() { }

        public void ConsultarPersona() 
        {
            Console.Clear();
            personaService.Consultar();

            Console.ReadKey();
        }

        public void ModificarPersona() { }

    }
}
