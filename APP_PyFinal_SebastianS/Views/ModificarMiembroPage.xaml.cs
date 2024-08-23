using APP_PyFinal_SebastianS.Models;
using APP_PyFinal_SebastianS.ViewModels;

namespace APP_PyFinal_SebastianS.Views;

public partial class ModificarMiembroPage : ContentPage
{
    MiembrosViewModel vm;

    public int MiembroId { get; set; }
	public ModificarMiembroPage(int miembroId)
	{
		InitializeComponent();

        BindingContext = vm = new MiembrosViewModel();

        MiembroId = miembroId;
        BuscarProyectobyId(miembroId);
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e) 
    {

        bool R = await vm.VmModificarMiembroAsync(Int32.Parse(TxtIdMiembro.Text),
                                            Int32.Parse(TxtIdRol.Text),
                                            TxtNombre.Text,
                                            TxtApellido.Text,
                                            TxtEmail.Text,
                                            Int32.Parse(TxtTelefono.Text)
            );
        if (R)
        {
            await DisplayAlert(":(", "Error", "OK");
        }
        else
        {

            await DisplayAlert(":)", "Miembro modificado Exitosamente", "Ok");
            await Navigation.PopAsync();
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    public async void BuscarProyectobyId(int miembroId)
    {
        TxtIdMiembro.Text = MiembroId.ToString();
        if (vm != null)
        {
            Miembro? miembro = await vm.VmBuscarMiembroByIdAsync(miembroId);
            if (miembro != null)
            {
                TxtIdRol.Text = miembro.RolId.ToString();
                TxtNombre.Text = miembro.Nombre.ToString();
                TxtApellido.Text = miembro.Apellidos.ToString();
                TxtEmail.Text = miembro.Email.ToString();
                TxtTelefono.Text = miembro.Telefono.ToString();
            }
            else
            {
                await DisplayAlert(":(", "No se encontro el Miembro", "Ok");
            }
        }
        else
        {
            await DisplayAlert(":(", "fuck", "Ok");
        }
    }

}