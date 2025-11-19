using ITGadgetSite.Model.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ITGadgetSite.Web;

public class ApiClient(HttpClient httpClient)
{
    public Task<T> GetFromJsonAsync<T>(string path)
    {
        return httpClient.GetFromJsonAsync<T>(path);
    }
    public async Task<T1> PostAsync<T1, T2>(string path, T2 postModel)
    {
        var response = await httpClient.PostAsJsonAsync(path, postModel);
        if (response != null && response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await response.Content.ReadAsStringAsync());
        }
        return default;
    }
    public async Task<T1>PutAsync<T1, T2>(string path, T2 postModel)
    {
        var response = await httpClient.PutAsJsonAsync(path, postModel);
        if (response != null && response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await response.Content.ReadAsStringAsync());
        }
        return default;
    }
}
                                                                                                                                                                                                                                                                                              