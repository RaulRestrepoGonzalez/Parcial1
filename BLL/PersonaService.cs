using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class PersonaService
    {

        PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guardar(Persona persona)
        {
            try
            {
                if (BuscarPorIdentificacion(persona.Id) == null)
                {
                    personaRepository.Guardar(persona);
                    return "Datos Guardados Satisfactoriamente";
                }
                return $"La Persona con la Identificacion {persona.Id} ya se encuentra registrada";

            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }
        }

        public Persona BuscarPorIdentificacion(int Id)
        {

            foreach (var item in Consultar().Personas)
            {
                if (item.Id.Equals(Id))
                {
                    return item;
                }
            }
            return null;
        }

        public ConsultaResponse Consultar()
        {
            try
            {
                return new ConsultaResponse(personaRepository.Consultar());
            }
            catch (Exception exception)
            {
                return new ConsultaResponse("Se presentó el siguiente error:" + exception.Message);
            }

        }

        public class ConsultaResponse
        {
            public List<Persona> Personas { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public ConsultaResponse(List<Persona> personas)
            {
                Personas = personas;
                Error = false;
            }

            public ConsultaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }

        }

    }
}
