using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class ListaRolPage : ContentPage
{
    RolViewModel vm;
    public ListaRolPage()
	{
		InitializeComponent();

        BindingContext = vm = new RolViewModel();

        LoadRolsList();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadRolsList();
    }

    private async void RolesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var selectedRol = e.SelectedItem as Rol;
        if (selectedRol != null)
        {
            await Navigation.PushAsync(new ModificarRolPage(selectedRol.RolId));
        }
    }

    private async void BtnAgregar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuardarRolPage());
    }

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {

        if (TxtBuscar.Text != "" && TxtBuscar.Text != null)
        {
            int miembroId = Int32.Parse(TxtBuscar.Text);
            if (miembroId != 0)
            {
                BuscarRolById(miembroId);
            }
            else
            {
                LoadRolsList();
            }

        }
        else
        {
            LoadRolsList();
        }
    }
        public async void LoadRolsList()
        {
            if (vm != null)
            {
                var miembros = await vm.VmGetRolsAsync();

                if (miembros != null)
                {
                    RolesListView.ItemsSource = miembros;
                }
            }
        }

        public async void BuscarRolById(int miembroId)
        {
            if (vm != null)
            {
                var miembros = await vm.VmBuscarRolByIdAsync(miembroId);

                if (miembros != null)
                {
                    RolesListView.ItemsSource = new List<Rol> { miembros };
                }
            }
        }

    }
