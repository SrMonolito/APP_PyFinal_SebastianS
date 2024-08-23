namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarProyectoPage : ContentPage
{
	public ModificarProyectoPage()
	{
		InitializeComponent();
	}

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}