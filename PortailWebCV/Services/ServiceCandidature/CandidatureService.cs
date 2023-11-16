using Microsoft.EntityFrameworkCore;
using PortailWebCV.Data;
using PortailWebCV.Models;
using PortailWebCV.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PortailWebCV.Services.ServiceCandidature
{
    
    public class CandidatureService : ICandidatureService
    {
        private readonly ApplicationDbContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _hosting;
        [Obsolete]
        public CandidatureService(ApplicationDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }
        [Obsolete]
        public async Task AddCondidatureAsync(CandidatureViewModel candidatureViewModel)
        {           
            string nomFichier = string.Empty;          
            if (candidatureViewModel.Fichier != null)
            {
                string uploads = Path.Combine(_hosting.WebRootPath, "uploads");
                string DossierCandidat = Path.Combine(uploads,candidatureViewModel.Nom + "_" +candidatureViewModel.Prénom);
                Directory.CreateDirectory(DossierCandidat);
                nomFichier = candidatureViewModel.Fichier.FileName;
                string url = Path.Combine(DossierCandidat, nomFichier);
                var fileStream = new FileStream(url,FileMode.Create);
                await candidatureViewModel.Fichier.CopyToAsync(fileStream);
            }
            Candidature candidature = new Candidature
            {          
                Nom = candidatureViewModel.Nom,
                Prénom = candidatureViewModel.Prénom,
                Mail = candidatureViewModel.Mail,
                Téléphone = candidatureViewModel.Téléphone,
                NiveauEtude = candidatureViewModel.NiveauEtude,
                AnnéesExpérience = candidatureViewModel.AnnéesExpérience,
                DernierEmployeur = candidatureViewModel.DernierEmployeur,
                FichierUrl = nomFichier
            };
            _context.Candidatures.Add(candidature);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Candidature>> GetCandidatesAsync()
        {
            return await _context.Candidatures.ToListAsync();
        }

        public async Task<List<Candidature>> RechercheCandidatAsync(string mot)
        {
            return await _context.Candidatures.Where(c => c.Nom.Contains(mot) || c.Prénom.Contains(mot) || c.Mail.Contains(mot) || c.Téléphone.Contains(mot)).ToListAsync();

        }

        public async Task SupprimerCandidatAsync(int candidatureId)
        {
            var candidature = await _context.Candidatures.FindAsync(candidatureId);
            if (candidature != null)
            {
                _context.Candidatures.Remove(candidature);
                await _context.SaveChangesAsync();
            }
        }
    }
}
