using System.ComponentModel.DataAnnotations;

namespace PortailWebCV.Models
{
    public class Candidature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nom { get; set; }
        [Required]
        public string? Prénom { get; set; }
        [Required]
        public string? Mail { get; set; }
        [Required]
        public string? Téléphone { get; set; }
        [Required]
        public string? NiveauEtude { get; set; }
        [Required]
        public int AnnéesExpérience { get; set; }
        [Required]
        public string? DernierEmployeur { get; set; }
        [Required]
        public string? FichierUrl { get; set; }
        

    }
}
