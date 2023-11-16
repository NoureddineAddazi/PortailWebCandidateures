using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortailWebCV.Services.ServiceCandidature;
using PortailWebCV.ViewModels;

namespace PortailWebCV.Controllers
{
    
    public class CandidatController : Controller
    {
        private readonly ICandidatureService _candidatureService;
        public CandidatController(ICandidatureService candidatureService)
        {
            _candidatureService = candidatureService;
        }
        
        public IActionResult Accueil()
        {
            return View();
        }
        public IActionResult Succes()
        {
            return View();
        }
        public IActionResult CréerCandidat()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CréerCandidat(CandidatureViewModel candidatureViewModel)
        {
            if(ModelState.IsValid)
            {
                await _candidatureService.AddCondidatureAsync(candidatureViewModel);
                return RedirectToAction(nameof(Succes));
            }
                return View();          
        }

    }
}
