using Microsoft.AspNetCore.Mvc;
using stock.Models;

namespace stock.Controllers;

public class MouvementController : Controller
{
    public IActionResult Index()
    {
        List<Magasin> magasins = Magasin.getAll();
        ViewBag.magasins = magasins;
        return View("/Views/Home/formSortie.cshtml");
    }

    [HttpPost]
    public IActionResult Submit(string date, string magasin, string article, string quantite)
    {
        try
        {
            Mouvement.insert(date, quantite, article, magasin);
            return RedirectToAction("Index", "Mouvement");
        }
        catch (Exception e)
        {
            List<Magasin> magasins = Magasin.getAll();
            ViewBag.magasins = magasins;
            ViewBag.message = e.Message;
            return View("/Views/Home/formSortie.cshtml");
        }
    }
}
