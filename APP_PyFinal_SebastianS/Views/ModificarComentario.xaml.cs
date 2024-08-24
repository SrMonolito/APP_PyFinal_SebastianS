using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarComentario : ContentPage
{
    ComentarioViewModel vm;

    public int ComentarioId { get; set; }
	public ModificarComentario(int comentarioId)
	{
		InitializeComponent();

        BindingContext = vm = new ComentarioViewModel();
        ComentarioId = comentarioId;

        BuscarComentarioById(comentarioId);

	}

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        bool R = await vm.VmModificarComentarioAsync(
                                            Int32.Parse(TxtComentarioId.Text),
                                            Int32.Parse(TxtMiembroId.Text),
                                            Int32.Parse(TxtTareaId.Text),
                                            DateOnly.Parse(TxtFecha.Text),
                                            TxtComentario.Text

            );
        if (R)
        {
            await DisplayAlert(":(", "Error", "OK");
        }
        else
        {

            await DisplayAlert(":)", "MiembroTarea modificado Exitosamente", "Ok");
            await Navigation.PopAsync();
        }
    }
    public async void BuscarComentarioById(int comentarioId)
    {
        TxtComentarioId.Text = ComentarioId.ToString();
        if (vm != null)
        {
            Comentario? comentario = await vm.VmBuscarComentarioByIdAsync(comentarioId);
            if (comentario != null)
            {
                TxtComentarioId.Text = comentario.ComentarioId.ToString();
                TxtMiembroId.Text = comentario.MiembroId.ToString();
                TxtTareaId.Text = comentario.TareaId.ToString();
                TxtFecha.Text = comentario.Fecha.ToString();
                TxtComentario.Text = comentario.Comentariotxt.ToString();
            }
            else
            {
                await DisplayAlert(":(", "No se encontro el Rol", "Ok");
            }
        }
        else
        {
            await DisplayAlert(":(", "fuck", "Ok");
        }
    }
}