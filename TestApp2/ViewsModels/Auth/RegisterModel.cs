using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp2.ViewsModels.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Le login est obligatoire")]
        [Display(Name = "Login *")]
        public string Login { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire")]
        [Display(Name = "Email *")]
        [DataType(DataType.EmailAddress, ErrorMessage = "L'adresse mail saisie n'est pas valide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe *")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmation de mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe *")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Le mot de passe de confirmation ne correspond pas")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Pays")]
        public string Country { get; set; }
        
        [Display(Name = "Âge")]
        public int? Age { get; set; }
    }
}