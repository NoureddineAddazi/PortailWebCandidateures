using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortailWebCV.Models;
using PortailWebCV.Services.ServiceCandidature;

namespace PortailWebCV.Controllers
{
    [Authorize ]
    public class AdminController : Controller
    {
        private readonly ICandidatureService _candidatureService;
        public AdminController(ICandidatureService candidatureService)
        {
            _candidatureService = candidatureService;
        }
        public async Task<IActionResult> ListeCandidats(string chaine)
        {
            List<Candidature> canditatures;

            if (!string.IsNullOrEmpty(chaine))
            {
                canditatures = await _candidatureService.RechercheCandidatAsync(chaine);
            }
            else
            {
                canditatures = await _candidatureService.GetCandidatesAsync();
            }
          
            return View(canditatures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupprimerCandidature(int candidatureId)
        {
            await _candidatureService.SupprimerCandidatAsync(candidatureId);
            return RedirectToAction(nameof(ListeCandidats));
        }

    }
}
