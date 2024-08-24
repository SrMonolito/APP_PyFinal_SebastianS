using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class GuardarComentarioPage : ContentPage
{
    ComentarioViewModel vm;
	public GuardarComentarioPage()
	{
		InitializeComponent();

        BindingContext = vm = new ComentarioViewModel();


	}

    private  async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async  void btnGuardar_Clicked(object sender, EventArgs e)
    {
        DateTime fecha = DateTime.Today;
        bool R = await vm.VmAddComentario(
            Int32.Parse(TxtMiembroId.Text),
            Int32.Parse(TxtTareaId.Text),
            DateOnly.FromDateTime(fecha),
            TxtComentario.Text
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
}