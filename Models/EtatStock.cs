using Newtonsoft.Json;

namespace stock.Models;
public class EtatStock
{
    public DateTime dateInitiale { get; set; }
    public DateTime dateFinale { get; set; }
    public Magasin magasin { get; set; }
    public List<Stock> listeStock { get; set; }
    public double montant {get;set;}
    public string Date1(){
        return dateInitiale.Date.ToString("dd-MM-yyyy");
    }
    public string Date2(){
        return dateFinale.Date.ToString("dd-MM-yyyy");
    }
    public static async Task<EtatStock> completeData(String date1, String date2, String magasin, String article){
        try{
            using(HttpClient client = new HttpClient()){
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("date1", date1),
                    new KeyValuePair<string, string>("date2", date2),
                    new KeyValuePair<string, string>("idArticle", article),
                    new KeyValuePair<string, string>("idMagasin", magasin)
                });
                string apiUrl = "http://localhost:1234/stock/etatStock";
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if(response.IsSuccessStatusCode){
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    EtatStock etatStock = JsonConvert.DeserializeObject<EtatStock>(responseBody);
                    return etatStock;
                }
                else{
                    return null;
                }
            }
        }
        catch(Exception e){
            throw e;
        }
    }
}
