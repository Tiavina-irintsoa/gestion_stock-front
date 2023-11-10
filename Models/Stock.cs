namespace stock.Models;

using System.Collections.Generic;

public class Stock
{
    public Article Article { get; set; }
    public double quantiteInitiale { get; set; }
    public double reste { get; set; }
    public double prixUnitaire { get; set; }
    public double montant { get; set; }
}
