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

    private async void btnRoles_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaRolPage());
    }

    private async void btnTareas_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaTareasPage());
    }

    private async void btnComentarios_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaComentariosPage());
    }

    private async void btnMiembrosTarea_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaMiembrosTareaPage());
    }
}