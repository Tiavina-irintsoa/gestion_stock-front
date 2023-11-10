namespace stock.Models;

public class Mouvement
{
    public static async Task insert(string date, string quantite, string article, string magasin)
    {
        string url = "http://localhost:1234/stock/ajoutSortie";
        var donneesFormulaire = new Dictionary<string, string>
        {
            { "date", date },
            { "quantite", quantite },
            { "article", article },
            { "magasin", magasin }
        };
        using (HttpClient client = new HttpClient())
        {
            var contenuFormulaire = new FormUrlEncodedContent(donneesFormulaire);

            HttpResponseMessage reponse = await client.PostAsync(url, contenuFormulaire);

            if (reponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Requête réussie !");
            }
            else
            {
                string contenuReponse = await reponse.Content.ReadAsStringAsync();

                throw new Exception(contenuReponse);
            }
        }
    }
}
