using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class ListaTareasPage : ContentPage
{
    TareasViewModel vm;
	public ListaTareasPage()
	{
		InitializeComponent();

        BindingContext = vm = new TareasViewModel();


	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTareasList();
    }
    private async void BtnAgregar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuardarTareaPage());
    }

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {
        if (TxtBuscar.Text != "" && TxtBuscar.Text != null)
        {
            int tareaId = Int32.Parse(TxtBuscar.Text);
            if (tareaId != 0)
            {
                BuscarRolById(tareaId);
            }
            else
            {
                LoadTareasList();
            }

        }
        else
        {
            LoadTareasList();
        }
    }

    private async void TareasListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var selectedRol = e.SelectedItem as Tarea;
        if (selectedRol != null)
        {
            await Navigation.PushAsync(new ModificarTareaPage(selectedRol.TareaId));
        }
    }

    public async void LoadTareasList()
    {
        if (vm != null)
        {
            var tareas = await vm.VmGetTareaAsync();

            if (tareas != null)
            {
                TareasListView.ItemsSource = tareas;
            }
        }
    }

    public async void BuscarRolById(int tareaId)
    {
        if (vm != null)
        {
            var tareas = await vm.VmBuscarTareaByIdAsync(tareaId);

            if (tareas != null)
            {
                TareasListView.ItemsSource = new List<Tarea> { tareas };
            }
        }
    }

}