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

            int cont = 0;

            while (cont == 0)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Digite la opcion: ");
                Console.WriteLine("1.Guardar");
                Console.WriteLine("2.Eliminar");
                Console.WriteLine("3.Consultar");
                Console.WriteLine("4.Modificar");
                Console.WriteLine("5.Salir");
                Console.WriteLine("----------------------------------");

                switch (Int32.Parse(Console.ReadLine()))
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
                        Console.Clear();

                        Console.WriteLine("Digite el ID: ");
                        int Id = int.Parse(Console.ReadLine());

                        personaService.Eliminar(Id);
                        break;
                    case 3:
                        Console.Clear();

                        if (personaService.Consultar().Personas != null)
                        {
                            foreach (var item in personaService.Consultar().Personas)
                            {
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine($"Id: {item.Id}");
                                Console.WriteLine($"Nombre: {item.Nombre}");
                                Console.WriteLine($"Tipo de sangre: {item.TipoSangre}");
                                Console.WriteLine($"Edad: {item.Edad}");
                            }
                        }else
                        {
                            Console.WriteLine(personaService.Consultar().Mensaje);
                        }
                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("Digite el ID: ");
                        Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite la edad: ");
                        int Edad = int.Parse(Console.ReadLine());

                        personaService.Modificar(Id, Edad);
                        break;
                    case 5:
                        Environment.Exit(cont = 1);
                        break;
                }

            }
            

            Console.ReadKey();
        }

    }
}
