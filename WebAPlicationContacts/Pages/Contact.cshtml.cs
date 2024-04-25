using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using WebAPlicationContacts.Entitys;
using WebAPlicationContacts.Logic;

namespace WebAPlicationContacts.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        [BindProperty]
        public int EditMode { get; set; }
        [BindProperty]
        public int usuario { get; set; }
        [BindProperty]
        public string Contact { get; set; }
        [BindProperty]
        [Required]
        public string Contactname { get; set; }
        [BindProperty]
        [Required]
        public string ContactTel { get; set; }
        [BindProperty]
        public string? ContactTel2 { get; set; }
        [BindProperty]
        [Required]
        public string ContactEmail { get; set; }
        [BindProperty]
        [AllowNull]
        public string? ContactEmail2 { get; set; }
        [BindProperty]
        [Required]
        public string ContactAddress { get; set; }
        [BindProperty]
        public string? ContactAddress2 { get; set; }


        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
        
      public JsonResult OnGetPersonas()
        {
            return new JsonResult(Logica.personas);
        }

        public IActionResult OnPost()
        {
            // Este método se llama cuando se envía el formulario (POST request)
            if (!ModelState.IsValid)
            {

                // Si hay errores de validación, regresa a la misma página
                return Page();
            }

            string result = "";

            if (this.EditMode == 0)
            {
                 result = Logica.RegistrarContacto(this.usuario, new Contact()
                {
                    Name = this.Contactname,
                    Tel1 = this.ContactTel,
                    Tel2 = this.ContactTel2,
                    Email1 = this.ContactEmail,
                    Email2 = this.ContactEmail2,
                    Address1 = this.ContactAddress,
                    Address2 = this.ContactAddress2

                });
            }
            else
            {
                result = Logica.ActualizarContacto(this.usuario, new Contact()
                {
                    Name = this.Contactname,
                    Tel1 = this.ContactTel,
                    Tel2 = this.ContactTel2,
                    Email1 = this.ContactEmail,
                    Email2 = this.ContactEmail2,
                    Address1 = this.ContactAddress,
                    Address2 = this.ContactAddress2

                });
            }

           
            TempData["Mensaje"] = result.Contains("Ok") ? result : result;
            TempData["Type"] = result.Contains("Ok") ? "Succes" : "Error";

            // Aquí puedes acceder a las propiedades Nombre y Email y hacer lo que necesites con ellas
            // Por ejemplo, guardar en la base de datos, enviar un correo electrónico, etc.

            return Page();
        }

    }
}
