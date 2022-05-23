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

        static void Main(string[] args)
        {
            PersonaService personaService = new PersonaService();

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
                    break;
                case 2:
                    //EliminarPersonba();
                    break;
                case 3:
                    Console.Clear();
                    personaService.Consultar();
                    break;
                case 4:
                    //ModificarPersona();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        }

    }
}
