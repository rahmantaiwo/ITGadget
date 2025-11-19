using Blazored.Toast.Services;
using ITGadgetSite.Model.Entities;
using ITGadgetSite.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace ITGadgetSite.Web.Components.Pages.Gadget
{
    public partial class UpdateGadget : ComponentBase
    {
        [Parameter]
        public Guid gadgetId { get; set; }
        public ITGadget Model { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
         private NavigationManager NavigationManager { get; set; }  

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var response = await ApiClient.GetFromJsonAsync<BaseResponse<ITGadget>>($"/api/Gadget/{gadgetId}");
            if (response != null && response.Success)
            {
                Model = response.Data;
            }
        }
        public async Task Submit()
        {
            var response = await ApiClient.PutAsync<BaseResponse<ITGadget>, ITGadget>($"/api/Gadget/{gadgetId}", Model);
            if (response != null && response.Success)
            {
                ToastService.ShowSuccess("Update product successfully");
                NavigationManager.NavigateTo("/gadget");
            }
            else
            {
                ToastService.ShowError("Failed to update gadget");
            }
        }
    }
}
