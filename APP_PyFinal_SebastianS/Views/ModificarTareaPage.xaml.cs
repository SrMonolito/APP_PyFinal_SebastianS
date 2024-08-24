using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarTareaPage : ContentPage
{
	TareasViewModel? vm;
	public int TareaId { get; set; }
	public ModificarTareaPage(int tareaId)
	{
		InitializeComponent();
		BindingContext = vm = new TareasViewModel();

		TareaId = tareaId;

	}

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {

        string gEstado;
        bool Estado = SwEstado.IsToggled;
        if (Estado == true)
        {
            gEstado = "A";
        }
        else
        {
            gEstado = "I";
        }

        bool R = await vm.VmModificarTareaAsync(Int32.Parse(TxtIdTarea.Text),
                                                Int32.Parse(TxtIdProyecto.Text),
                                                TxtNombre.Text,
                                                TxtDescripcion.Text,
                                                DateOnly.FromDateTime(DpFechaInicio.Date),
                                                DateOnly.FromDateTime(DpFechaFin.Date),
                                                gEstado
            );
        if (R)
        {
            await DisplayAlert(":(", "Error", "OK");
        }
        else
        {

            await DisplayAlert(":)", "Tarea modificado Exitosamente", "Ok");
            await Navigation.PopAsync();
        }
    }

    public async void BuscarProyectobyId(int tareaId)
    {
        TxtIdProyecto.Text = TareaId.ToString();
        if (vm != null)
        {
            Tarea? tarea = await vm.VmBuscarTareaByIdAsync(tareaId);
            if (tarea != null)
            {
                TxtIdProyecto.Text = tarea.ProyectoId.ToString();
                TxtNombre.Text = tarea.Nombre.ToString();
                TxtDescripcion.Text = tarea.Descripcion.ToString();
                DpFechaInicio.Date = tarea.FechaInicio.ToDateTime(TimeOnly.MinValue);
                DpFechaFin.Date = tarea.FechaFin.ToDateTime(TimeOnly.MinValue);
                string Estado = tarea.Estado.ToString();
                if (Estado == "A")
                {
                    SwEstado.IsToggled = true;
                }
                else
                {
                    SwEstado.IsToggled = false;
                }
            }
            else
            {
                await DisplayAlert(":(", "No se encontro el tarea", "Ok");
            }
        }
        else
        {
            await DisplayAlert(":(", "fuck", "Ok");
        }
    }

}