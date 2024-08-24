using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class GuardarTareaPage : ContentPage
{
	TareasViewModel vm;
	public GuardarTareaPage()
	{
		InitializeComponent();
		BindingContext = vm = new TareasViewModel();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        string gEstado;
        bool Estado = SwEstado.IsToggled;
        if (Estado == true)
        {
            gEstado = "A";
        }
        else
        {
            gEstado = "I";
        }

        bool R = await vm.VmAddTarea(Int32.Parse(TxtIdProyecto.Text),
                                        TxtNombre.Text,
                                        TxtDescripcion.Text,
                                        DateOnly.FromDateTime(DpFechaFin.Date),
                                        DateOnly.FromDateTime(DpFechaInicio.Date),
                                        gEstado
            );
        if (R)
        {
            await DisplayAlert(":)", "Tarea añadida Exitosamente", "Ok");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert(":(", "Error", "OK");
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}