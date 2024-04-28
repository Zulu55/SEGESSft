using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SEGES.FrontEnd.Repositories;
using SEGES.FrontEnd.Shared;
using SEGES.Shared.Entities;


namespace SEGES.FrontEnd.Pages.Cities
{
    public partial class CitiesCreate
    {
        private City city = new();
        private FormWithName<City>? cityForm;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int StateId { get; set; }

        private async Task CreateAsync()
        {
            city.StateId = StateId;
            var responseHttp = await Repository.PostAsync("/api/cities", city);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito.");
        }

        private void Return()
        {
            cityForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/states/details/{StateId}");
        }
    }
}
