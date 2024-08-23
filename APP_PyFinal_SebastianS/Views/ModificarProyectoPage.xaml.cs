namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarProyectoPage : ContentPage
{
	public int ProyectoId { get; set; }
	public ModificarProyectoPage(int proyectoId)
	{
		InitializeComponent();

		ProyectoId = proyectoId;

		TxtIdProyecto.Text = ProyectoId.ToString();

    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}