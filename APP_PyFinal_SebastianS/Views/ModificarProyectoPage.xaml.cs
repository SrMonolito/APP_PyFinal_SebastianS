using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarProyectoPage : ContentPage
{
    ProyectosViewModel? vm;
    public int ProyectoId { get; set; }
    public ModificarProyectoPage(int proyectoId)
    {
        InitializeComponent();

        BindingContext = vm = new ProyectosViewModel();

        ProyectoId = proyectoId;
        BuscarProyectobyId(ProyectoId);


    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    public async void BuscarProyectobyId(int proyectoId)
    {
        TxtIdProyecto.Text = ProyectoId.ToString();
        if (vm != null)
        {
            Proyecto? proyecto = await vm.VmBuscarProyectoByIdAsync(proyectoId);
            if (proyecto != null)
            {
                TxtNombre.Text = proyecto.Nombre.ToString();
                TxtDescripcion.Text = proyecto.Descripcion.ToString();
                DpFechaInicio.Date = proyecto.FechaInicio.ToDateTime(TimeOnly.MinValue);
                DpFechaFin.Date = proyecto.FechaFin.ToDateTime(TimeOnly.MinValue);
                string Estado = proyecto.Estado.ToString();
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
                await DisplayAlert(":(", "No se encontro el proyecto", "Ok");
            }
        }
        else
        {
            await DisplayAlert(":(", "fuck", "Ok");
        }
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

        bool R = await vm.VmModificarProyectoAsync(Int32.Parse(TxtIdProyecto.Text),
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

            await DisplayAlert(":)", "Proyecto añadido Exitosamente", "Ok");
            await Navigation.PopAsync();
        }

    }
}