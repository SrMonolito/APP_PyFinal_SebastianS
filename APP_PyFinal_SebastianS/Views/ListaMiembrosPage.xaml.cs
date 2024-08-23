using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class ListaMiembrosPage : ContentPage
{
    MiembrosViewModel vm;
    public ListaMiembrosPage()
    {
        InitializeComponent();

        BindingContext = vm = new MiembrosViewModel();

        LoadMiembrosList();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadMiembrosList();
    }

   

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {
        if (TxtBuscar.Text != "" && TxtBuscar.Text != null)
        {
            int miembroId = Int32.Parse(TxtBuscar.Text);
            if (miembroId != 0)
            {
                BuscarMiembroById(miembroId);
            }
            else
            {
                LoadMiembrosList();
            }

        }
        else
        {
            LoadMiembrosList();
        }
    }
    

    private async void BtnAddMiembro_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuardarMiembroPage());
    }

    private async void MiembrosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var selectedMiembro = e.SelectedItem as Miembro;
        if (selectedMiembro != null)
        {
            await Navigation.PushAsync(new ModificarMiembroPage(selectedMiembro.MiembroId));
        } 
    }

    public async void LoadMiembrosList()
    {
        if (vm != null)
        {
            var miembros = await vm.VmGetMiembrosAsync();

            if (miembros != null)
            {
                MiembrosListView.ItemsSource = miembros;
            }
        }
    }

    public async void BuscarMiembroById(int miembroId)
    {
        if (vm != null)
        {
            var miembros = await vm.VmBuscarMiembroByIdAsync(miembroId);

            if (miembros != null)
            {
                MiembrosListView.ItemsSource = new List<Miembro> { miembros };
            }
        }
    }

}