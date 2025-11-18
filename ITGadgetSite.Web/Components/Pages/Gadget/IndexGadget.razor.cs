using Google.Protobuf.WellKnownTypes;
using ITGadgetSite.Model.Entities;
using ITGadgetSite.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITGadgetSite.Web.Components.Pages.Gadget
{
    public partial class IndexGadget
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public IEnumerable<ITGadget> GadgetModels { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var response = await ApiClient.GetFromJsonAsync<BaseResponse<IEnumerable<ITGadget>>>("/api/Gadget");
            //var response = await Api.GetGadgetsAsync();
            if (response != null && response.Success)
            {
                GadgetModels = response.Data.ToList();
                //GadgetModels = JsonConvert.DeserializeObject<IEnumerable<ITGadget>>(response.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}