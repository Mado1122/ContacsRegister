using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebAPlicationContacts.Entitys;
using WebAPlicationContacts.Logic;

namespace WebAPlicationContacts.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "La propiedad debe contener solo caracteres alfanum�ricos.")]
        public int Identification { get; set; }
        [BindProperty]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La propiedad debe contener solo caracteres del alfabeto latino y espacios.")]
        public string Names { get; set; }
        [BindProperty]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La propiedad debe contener solo caracteres del alfabeto latino.")]
        public string LastNames { get; set; }
        [BindProperty]
        public string BirthDate { get; set; }
        [BindProperty]
        public string Contactname { get; set; }
        [BindProperty]
        public string ContactTel { get; set; }
        [BindProperty]
        public string ContactEmail { get; set; }
        [BindProperty]
        public string ContactAddress { get; set; }
  

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            // Este m�todo se llama cuando se env�a el formulario (POST request)
            if (!ModelState.IsValid)
            {
                
                // Si hay errores de validaci�n, regresa a la misma p�gina
                return  Page();
            }

            Persona persona = new Persona();
            persona.Identification = Identification;
            persona.Names = Names;
            persona.LastNames = LastNames;
            persona.BirthDate = BirthDate;
            persona.Contacts = new List<Contact>();
            persona.Contacts.Add(new Contact
            {
                Address1 = ContactAddress,
                Email1 = ContactEmail,
                Tel1 = ContactTel,
                Name = Contactname
            });

            string result = Logica.Registrarpersona(persona);



            TempData["Mensaje"] = result.Equals("Ok") ? "�Persona Registrada correctamente!" : result;
            TempData["Type"] = result.Equals("Ok") ? "Succes" : "Error";

            // Aqu� puedes acceder a las propiedades Nombre y Email y hacer lo que necesites con ellas
            // Por ejemplo, guardar en la base de datos, enviar un correo electr�nico, etc.

            return Page();
        }
    
}
}
