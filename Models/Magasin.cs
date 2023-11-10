using Newtonsoft.Json;

namespace stock.Models;
public class Magasin
{
    public int idMagasin { get; set; }
    public string nomMagasin { get; set; }
    public static List<Magasin> getAll(){
        using (HttpClient client = new HttpClient()){
            string apiUrl = "http://localhost:1234/stock/magasins";
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
                    {
                        // Lisez le contenu de la réponse (par exemple, JSON).
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        List<Magasin> liste = JsonConvert.DeserializeObject<List<Magasin>>(responseBody);
                        return liste;    
                }
                else{
                    return null;
                }
        }
    }
}
