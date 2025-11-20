using Blazored.Toast.Services;
using Google.Protobuf.WellKnownTypes;
using ITGadgetSite.Model.Entities;
using ITGadgetSite.Model.Models;
using ITGadgetSite.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ITGadgetSite.Web.Components.Pages.Gadget
{
    public partial class IndexGadget
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        public IEnumerable<ITGadget> GadgetModels { get; set; }
        public AppModal Modal { get; set; }
        public Guid DeleteId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadGadget();
        }
        protected async Task LoadGadget()
        {
            var response = await ApiClient.GetFromJsonAsync<BaseResponse<IEnumerable<ITGadget>>>("/api/Gadget/get-all-gadget");
            if (response != null && response.Success)
            {
                GadgetModels = response.Data.ToList();
            }
            await base.OnInitializedAsync();
        }
        protected async Task HandleDelete()
        {
            var response = await ApiClient.DeleteAsync<BaseResponse<ITGadget>>($"/api/gadget/{DeleteId}");
            if (response != null && response.Success)
            {
                ToastService.ShowSuccess("Delete product successfully");
                await LoadGadget();
                Modal.Close();
            }
        }
    }
}