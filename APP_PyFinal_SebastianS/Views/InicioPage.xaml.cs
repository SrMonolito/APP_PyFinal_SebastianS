namespace APP_PyFinal_SebastianS.Views;

public partial class InicioPage : ContentPage
{
	public InicioPage()
	{
		InitializeComponent();
	}

    private async void btnProyectos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaProyectosPage(0));
    }

    private async void btnMiembros_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaMiembrosPage());
    }
}