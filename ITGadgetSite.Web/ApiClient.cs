using ITGadgetSite.Model.Models;
using static System.Net.WebRequestMethods;

namespace ITGadgetSite.Web;

public class ApiClient(HttpClient httpClient)
{
    public Task<T> GetFromJsonAsync<T>(string path)
    {
        return httpClient.GetFromJsonAsync<T>(path);
    }

}
