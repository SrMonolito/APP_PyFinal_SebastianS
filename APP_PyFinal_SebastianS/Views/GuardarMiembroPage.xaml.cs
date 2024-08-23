using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class GuardarMiembroPage : ContentPage
{
    MiembrosViewModel vm;
	public GuardarMiembroPage()
	{
		InitializeComponent();

        BindingContext = vm = new MiembrosViewModel();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {

        bool R = await vm.VmAddMiembro(
            Int32.Parse(TxtIdRol.Text),
            TxtNombre.Text,
            TxtApellido.Text,
            TxtEmail.Text,
            Int32.Parse(TxtTelefono.Text)
            );
        if (R)
        {
            await DisplayAlert(":)", "Proyecto añadido Exitosamente", "Ok");
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