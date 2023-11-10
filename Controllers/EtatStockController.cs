using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using stock.Models;

namespace stock.Controllers;

public class EtatStockController : Controller
{
    public IActionResult Index()
    {
        List<Magasin> magasins = Magasin.getAll();
        ViewBag.magasins = magasins;
        return View("/Views/Home/formStock.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> Submit(
        string date1,
        string date2,
        string article,
        string magasin
    )
    {
        EtatStock e = await EtatStock.completeData(date1, date2, magasin, article);
        ViewBag.etatStock = e;
        return View("/Views/Home/etatStock.cshtml");
    }
}
