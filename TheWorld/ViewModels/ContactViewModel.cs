using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Por favor introduzaca una direccion de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(4096, MinimumLength = 10, ErrorMessage = "El campo Mensaje debe ser una cadena con una longitud mínima de 10 y una longitud máxima de 4096")]
        public string Message { get; set; } 
    }
}
