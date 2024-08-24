using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class ListaMiembrosTareaPage : ContentPage
{
    MiembroTareaViewModel vm;
    public ListaMiembrosTareaPage()
	{
		InitializeComponent();

        BindingContext = vm = new MiembroTareaViewModel();

        LoadmiembtareaList();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadmiembtareaList();
    }
    private async void BtnAgregar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuardarMiembroTareaPage());
    }

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {

        if (TxtBuscar.Text != "" && TxtBuscar.Text != null)
        {
            int miembroId = Int32.Parse(TxtBuscar.Text);
            if (miembroId != 0)
            {
                BuscarMiembroTareaById(miembroId);
            }
            else
            {
                LoadmiembtareaList();
            }

        }
        else
        {
            LoadmiembtareaList();
        }
    }

    private async void MiembTareaListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var selectedMiembroTarea = e.SelectedItem as MiembroTarea;
        if (selectedMiembroTarea != null)
        {
            await Navigation.PushAsync(new ModificarMiembroTareaPage(selectedMiembroTarea.MiembTareaId));
        }
    }

    public async void LoadmiembtareaList()
    {
        if (vm != null)
        {
            var miembros = await vm.VmGetMiembroTareasAsync();

            if (miembros != null)
            {
                MiembTareaListView.ItemsSource = miembros;
            }
        }
    }
    public async void BuscarMiembroTareaById(int miembroId)
    {
        if (vm != null)
        {
            var miembros = await vm.VmBuscarMiembroTareaByIdAsync(miembroId);

            if (miembros != null)
            {
                MiembTareaListView.ItemsSource = new List<MiembroTarea> { miembros };
            }
        }
    }
}