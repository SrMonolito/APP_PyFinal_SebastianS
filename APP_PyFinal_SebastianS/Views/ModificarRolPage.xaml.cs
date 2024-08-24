using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarRolPage : ContentPage
{
    RolViewModel vm;

    public int RolId { get; set; }
    public ModificarRolPage(int rolId)
	{
		InitializeComponent();

        BindingContext = vm = new RolViewModel();

        RolId = rolId;
        BuscarRolbyId(rolId);

    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {

        bool R = await vm.VmModificarRolAsync(
                                            Int32.Parse(TxtIdRol.Text),
                                            TxtNombre.Text,
                                            TxtDescripcion.Text
            );
        if (R)
        {
            await DisplayAlert(":(", "Error", "OK");
        }
        else
        {

            await DisplayAlert(":)", "Rol modificado Exitosamente", "Ok");
            await Navigation.PopAsync();
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    public async void BuscarRolbyId(int rolId)
    {
        TxtIdRol.Text = RolId.ToString();
        if (vm != null)
        {
            Rol? rol = await vm.VmBuscarRolByIdAsync(rolId);
            if (rol != null)
            {
                TxtIdRol.Text = rol.RolId.ToString();
                TxtNombre.Text = rol.Nombre.ToString();
                TxtDescripcion.Text = rol.Descripcion.ToString();
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