using System.ComponentModel.DataAnnotations;

namespace PortailWebCV.ViewModels
{
    public class CandidatureViewModel
    {
        
        [Required(ErrorMessage = "Veuillez Ajouter votre nom")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "Veuillez Ajouter votre prénom")]
        public string? Prénom { get; set; }
        [Required(ErrorMessage = "Veuillez Ajouter votre adresse mail")]
        public string? Mail { get; set; }
        [Required(ErrorMessage = "Veuillez Ajouter votre numéro de téléphone")]
        public string? Téléphone { get; set; }
        [Required(ErrorMessage = "Veuillez Ajouter votre niveau d'étude")]
        public string? NiveauEtude { get; set; }
        [Required(ErrorMessage = "Veuillez Ajouter votre années d'expérience")]
        public int AnnéesExpérience { get; set; }
        [Required(ErrorMessage = "Veuillez Ajouter votre dernier employeur")]
        public string? DernierEmployeur { get; set; }
        [Required(ErrorMessage = "Veuillez séléctionner votre CV")]
        public IFormFile? Fichier { get; set; }
    }
}
