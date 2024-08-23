using APP_PyFinal_SebastianS.Views;
using APP_PyFinal_SebastianS.ViewModels;
using APP_PyFinal_SebastianS.Models;
namespace APP_PyFinal_SebastianS.Views;

public partial class ListaProyectosPage : ContentPage
{

	ProyectosViewModel? vm;

	public ListaProyectosPage()
	{
		InitializeComponent();

		BindingContext = vm = new ProyectosViewModel();

		LoadProyectosList();
	}

	private async void LoadProyectosList()
	{
        if (vm != null)
        {
            var proyectos = await vm.VmGetProyectosAsync();

            if (proyectos != null)
            {
                ProyectosListView.ItemsSource = proyectos;
            }
        }
    }

    private async void BtnAddProject_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new GuardarProyectoPage());
		}

    private async void ProyectosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;

        var SelectedProyecto = e.SelectedItem as Proyecto;

        if(SelectedProyecto != null)
        {
            await Navigation.PushAsync(new ModificarProyectoPage(SelectedProyecto.ProyectoId));
        }
    }

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {

    }
}