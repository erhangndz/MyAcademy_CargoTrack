using CargoTrack.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoTrack.WebUI.Controllers
{
    public class DefaultController(AppDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }
            return View();
        }

        public async Task<IActionResult> CargoDetails(string trackCode)
        {
            var cargo = await _context.Cargos.FirstOrDefaultAsync(x=>x.TrackCode== trackCode);

            if(cargo is null)
            {
                TempData["error"] = "Bu Takip Numarasına Ait Bir Kargo Bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            return View(cargo);

        }
        

    }
}
