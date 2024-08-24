using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class ListaComentariosPage : ContentPage
{
    ComentarioViewModel vm;
	public ListaComentariosPage()
	{
		InitializeComponent();

        BindingContext = vm = new ComentarioViewModel();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadtareaList();
    }

    private async void ComentarioListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;
        var selectedComentario = e.SelectedItem as Comentario;
        if (selectedComentario != null)
        {
            await Navigation.PushAsync(new ModificarComentario(selectedComentario.ComentarioId));
        }
    }

    private async void BtnAgregar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GuardarComentarioPage());
    }

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {

        if (TxtBuscar.Text != "" && TxtBuscar.Text != null)
        {
            int comentarioId = Int32.Parse(TxtBuscar.Text);
            if (comentarioId != 0)
            {
                BuscarComentarioById(comentarioId);
            }
            else
            {
                LoadtareaList();
            }

        }
        else
        {
            LoadtareaList();
        }
    }

    public async void BuscarComentarioById(int comentarioId)
    {
        if (vm != null)
        {
            var comentarios = await vm.VmBuscarComentarioByIdAsync(comentarioId);

            if (comentarios != null)
            {
                ComentarioListView.ItemsSource = new List<Comentario> { comentarios };
            }
        }
    }

    public async void LoadtareaList()
    {
        if (vm != null)
        {
            var comentarios = await vm.VmGetComentariosAsync();

            if (comentarios != null)
            {
                ComentarioListView.ItemsSource = comentarios;
            }
        }
    }

}