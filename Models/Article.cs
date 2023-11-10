namespace stock.Models;

public class Article
{
    public string idArticle { get; set; }
    public string nomArticle { get; set; }
    public string methodeStockage { get; set; }
    public Unite unite { get; set; }
}
