namespace APP_PyFinal_SebastianS.Views;

public partial class GuardarProyectoPage : ContentPage
{
	public GuardarProyectoPage()
	{
		InitializeComponent();
	}

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {

    }
}