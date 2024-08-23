using APP_PyFinal_SebastianS.Views;
using APP_PyFinal_SebastianS.ViewModels;
using APP_PyFinal_SebastianS.Models;
namespace APP_PyFinal_SebastianS.Views;

public partial class ListaProyectosPage : ContentPage
{

	ProyectosViewModel? vm;

	public ListaProyectosPage(int proyectoId)
	{
		InitializeComponent();

		BindingContext = vm = new ProyectosViewModel();

		LoadProyectosList();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
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


        if (TxtBuscar.Text != "" && TxtBuscar.Text != null)
        {
            int proyectoId = Int32.Parse(TxtBuscar.Text);
            if (proyectoId != 0)
            {
                buscarProyecto(proyectoId);
            }
            else
            {
                LoadProyectosList();
            }
            
        }
        else
        {
            LoadProyectosList();
        }
        
    }
    public async void buscarProyecto(int proyectoId)
    {
        if (vm != null)
        {
            var proyectos = await vm.VmBuscarProyectoByIdAsync(proyectoId);

            if (proyectos != null)
            {
                ProyectosListView.ItemsSource = new List<Proyecto> { proyectos };
            }
        }
    }
}