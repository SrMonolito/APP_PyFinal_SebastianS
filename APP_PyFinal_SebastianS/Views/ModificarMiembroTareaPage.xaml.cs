using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;
namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarMiembroTareaPage : ContentPage
{
    MiembroTareaViewModel vm;

    public int MiembroTareaId;

    public ModificarMiembroTareaPage(int miembrotareaId)
	{
		InitializeComponent();

        BindingContext = vm = new MiembroTareaViewModel();

        MiembroTareaId = miembrotareaId;
        BuscarMiembroTareabyId(miembrotareaId);

    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        bool R = await vm.VmModificarMiembroTareaAsync(
                                            Int32.Parse(TxtMiembroTareaId.Text),
                                            Int32.Parse(TxtMiembroId.Text),
                                            Int32.Parse(TxtTareaId.Text)
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

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    public async void BuscarMiembroTareabyId(int miembrotareaId)
    {
        TxtMiembroTareaId.Text = MiembroTareaId.ToString();
        if (vm != null)
        {
            MiembroTarea? MbTarea = await vm.VmBuscarMiembroTareaByIdAsync(miembrotareaId);
            if (MbTarea != null)
            {
                TxtMiembroTareaId.Text = MbTarea.MiembTareaId.ToString();
                TxtMiembroId.Text = MbTarea.MiembroId.ToString();
                TxtTareaId.Text = MbTarea.TareaId.ToString();
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