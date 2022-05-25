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
            ConsultaResponse response;

            try
            {
                response = new ConsultaResponse(personaRepository.Consultar());
                return response;
            }
            catch (Exception exception)
            {
                response = new ConsultaResponse("Se presentó el siguiente error:" + exception.Message);
                response.Personas = null;
                return response;
            }

        }

        public string Eliminar(int Id)
        {
            try
            {
                if (personaRepository.Buscar(Id) != null)
                {
                    personaRepository.Eliminar(Id);
                    return $"se elimino la liquidacion numero: {Id} correctamente";
                }
                return $"El numero de liquidacion no esta registrado en el sistema";
            }
            catch (Exception e)
            {
                return $"ERROR" + e.Message;
            }
        }

        public string Modificar(int Id, int Edad)
        {
            try
            {
                if (personaRepository.Buscar(Id) != null)
                {
                    personaRepository.Modificar(Id, Edad);
                    return $"la liquidacion numero: {Id} ha sido modificada con exito!";

                }
                return $"El numero de liquidacion: {Id} no se encuentra registrada por favor verifique los datos";

            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
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
