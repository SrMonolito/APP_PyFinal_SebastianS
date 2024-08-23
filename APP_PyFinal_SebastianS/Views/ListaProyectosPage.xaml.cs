using APP_PyFinal_SebastianS.Views;

namespace APP_PyFinal_SebastianS.Views;

public partial class ListaProyectosPage : ContentPage
{
	public ListaProyectosPage()
	{
		InitializeComponent();
	}

    private async void BtnAddProject_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new GuardarProyectoPage());
		}
	}