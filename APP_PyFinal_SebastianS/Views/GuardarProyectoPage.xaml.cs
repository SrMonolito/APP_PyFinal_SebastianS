namespace APP_PyFinal_SebastianS.Views;
using APP_PyFinal_SebastianS.ViewModels;
public partial class GuardarProyectoPage : ContentPage
{
    ProyectosViewModel? vm;
    public GuardarProyectoPage()
	{
		InitializeComponent();

        BindingContext = vm = new ProyectosViewModel();
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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

        bool R = await vm.VmAddProyecto(TxtNombre.Text,
                                        TxtDescripcion.Text,
                                        DateOnly.FromDateTime(DpFechaFin.Date),
                                        DateOnly.FromDateTime(DpFechaInicio.Date),
                                        gEstado
            );
        if (R) 
        {
            await DisplayAlert(":)", "Proyecto añadido Exitosamente", "Ok");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert(":(","Error","OK");
        }
    }
}