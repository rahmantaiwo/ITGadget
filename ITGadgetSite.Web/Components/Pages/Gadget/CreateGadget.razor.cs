using Blazored.Toast.Services;
using ITGadgetSite.Model.Entities;
using ITGadgetSite.Model.Models;
using Microsoft.AspNetCore.Components;   

namespace ITGadgetSite.Web.Components.Pages.Gadget
{
    public partial class CreateGadget
    {
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public ITGadget Model { get; set; } = new();
        public async Task Submit()
        {
            var response = await ApiClient.PostAsync<BaseResponse<ITGadget>, ITGadget>("/api/Gadget/create", Model);
            if (response != null && response.Success)
            {
                ToastService.ShowSuccess("Create gadget successfully");
                NavigationManager.NavigateTo("/gadget");
            }
        }
    }
}
