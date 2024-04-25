using WebAPlicationContacts.Entitys;

namespace WebAPlicationContacts.Logic
{   

    public class Logica
    {
        public static List<Persona> personas = new List<Persona>();

        public static string Registrarpersona(Persona persona)
        {   

            if(personas.Any(p => p.Identification == persona.Identification))
            {
                return "Persona ya existe";
            }

            personas.Add(persona);

            return "Ok";
        }

        public static string RegistrarContacto(int Identificacion, Contact contacto)
        {
            Persona persona = personas.FirstOrDefault(p => p.Identification == Identificacion);

            if (persona != null)
            {
                if( persona.Contacts.Any(c => c.Name == contacto.Name))
                {
                   
                    return "Contacto ya registrado";
                    
                }
                else
                {
                    persona.Contacts.Add(contacto);
                    return "Ok,Contacto Registrado Correctamente";
                }

            }
            else
            {
                return "Persona no registrada";
            }

            
        }

        public static string ActualizarContacto(int Identificacion, Contact contacto)
        {
            Persona persona = personas.FirstOrDefault(p => p.Identification == Identificacion);

            if (persona != null)
            {
                if (persona.Contacts.Any(c => c.Name == contacto.Name))
                {
                    Contact contactoo = persona.Contacts.FirstOrDefault(c => c.Name == contacto.Name);
                    contactoo.Name = contacto.Name;
                    contactoo.Email1 = contacto.Email1;
                    contactoo.Email2 = contacto.Email2;
                    contactoo.Tel1 = contacto.Tel1;
                    contactoo.Tel2 = contacto.Tel2;
                    contactoo.Address1 = contacto.Address1;
                    contactoo.Address2 = contacto.Address2;

                    return "Ok,Contacto Actualizado Correctamente";

                }
                else
                {
                    return "Contacto no existe";
                }

            }
            else
            {
                return "Persona no registrada";
            }


        }

    }
}
