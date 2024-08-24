using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class GuardarRolPage : ContentPage
{
    RolViewModel vm;
    public GuardarRolPage()
	{
		InitializeComponent();

        BindingContext = vm = new RolViewModel();
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {

        bool R = await vm.VmAddRol(
            TxtNombre.Text,
            TxtDescripcion.Text
            );
        if (R)
        {
            await DisplayAlert(":)", "Rol añadido Exitosamente", "Ok");
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