using ITGadgetSite.Model.Entities;
using ITGadgetSite.Model.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace ITGadgetSite.Web.Components.Pages.Gadget
{
    public partial class IndexGadget
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public IEnumerable<ITGadget> ITGadgets { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var response = await ApiClient.GetFromJsonAsync<BaseResponse<ITGadget>>("/api/Gadget");
            if (response != null && response.Success)
            {
                //ITGadgets = JsonConverter.DeserializeObject()
            }
            //return base.OnInitializedAsync();
        }
    }
}