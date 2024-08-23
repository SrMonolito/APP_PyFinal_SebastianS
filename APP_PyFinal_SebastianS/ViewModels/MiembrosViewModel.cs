using APP_PyFinal_SebastianS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PyFinal_SebastianS.ViewModels
{
    public class MiembrosViewModel : BaseViewModel
    {
        public Miembro MyMiembro { get; set; }

        public MiembrosViewModel()
        {
            MyMiembro = new Miembro();
        }

        public async Task<List<Miembro>?> VmGetMiembrosAsync()
        {
            try
            {
                List<Miembro>? miembros = new List<Miembro>();
                miembros = await MyMiembro.GetMiembrosAsync();
                if (miembros == null) return null;

                return miembros;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VmAddMiembro(int pRolId,
            string pNombre,
                                              string pApellidos,
                                              string pEmail,
                                              int pTelefono
            )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyMiembro = new()
                {
                    Nombre = pNombre,
                    Apellidos = pApellidos,
                    Email = pEmail,
                    Telefono = pTelefono
                };
                bool Ret = (bool)await MyMiembro.AddMiembroAsync();
                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<Miembro?> VmBuscarMiembroByIdAsync(int miembroid)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                Miembro? miembro = await MyMiembro.BuscarProyectoByIdAsync(miembroid);
                if (miembro != null)
                {
                    MyMiembro = miembro;
                }
                return miembro;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> VmModificarMiembroAsync(int miembroId,
                                                        int pRolId,
                                                        string pNombre,
                                                        string pApellidos,
                                                        string pEmail,
                                                        int pTelefono)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                Miembro miembro = new Miembro
                {
                    MiembroId = miembroId,
                    RolId = pRolId,
                    Nombre = pNombre,
                    Apellidos = pApellidos,
                    Email = pEmail,
                    Telefono = pTelefono

                };

                bool resultado = await miembro.ModificarMiembroAsync(miembro);
                return resultado;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
