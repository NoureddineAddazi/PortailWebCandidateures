using PortailWebCV.Models;
using PortailWebCV.ViewModels;

namespace PortailWebCV.Services.ServiceCandidature
{
    public interface ICandidatureService
    {
        Task AddCondidatureAsync(CandidatureViewModel candidateurViewModel);
        Task<List<Candidature>> GetCandidatesAsync();

        Task<List<Candidature>> RechercheCandidatAsync(string mot);

        Task SupprimerCandidatAsync(int candidatureId);
    }
}
