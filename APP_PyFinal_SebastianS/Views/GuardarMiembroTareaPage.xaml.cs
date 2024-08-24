using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class GuardarMiembroTareaPage : ContentPage
{
    MiembroTareaViewModel vm;
	public GuardarMiembroTareaPage()
	{
		InitializeComponent();

        BindingContext = vm = new MiembroTareaViewModel();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        bool R = await vm.VmAddMiembroTarea(
            Int32.Parse(TxtMiembroId.Text),
            Int32.Parse(TxtTareaId.Text)
            );
        if (R)
        {
            await DisplayAlert(":)", "MiembroTarea añadido Exitosamente", "Ok");
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