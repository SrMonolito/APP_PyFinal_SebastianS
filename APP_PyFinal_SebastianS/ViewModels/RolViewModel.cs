
using APP_PyFinal_SebastianS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PyFinal_SebastianS.ViewModels
{
    public class RolViewModel : BaseViewModel
    {
        public Rol MyRol { get; set; }

        public RolViewModel()
        {
            MyRol = new Rol();
        }

        //Funcion que carga los rols para mostrar en la tableview
        public async Task<List<Rol>?> VmGetRolsAsync()
        {
            try
            {
                List<Rol>? rols = new List<Rol>();
                rols = await MyRol.GetRolArync();
                if (rols == null) return null;

                return rols;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VmAddRol(string pNombre,
                                              string pDescripcion
            )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyRol = new()
                {
                    Nombre = pNombre,
                    Descripcion = pDescripcion
                };
                bool Ret = (bool)await MyRol.AddRolAsync();
                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<Rol?> VmBuscarRolByIdAsync(int rolId)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                Rol? rol = await MyRol.BuscarRolByIdAsync(rolId);
                if (rol != null)
                {
                    MyRol = rol;
                }
                return rol;
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

        public async Task<bool> VmModificarRolAsync(int rolId,
                                                         string pNombre,
                                                         string pDescripcion)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                Rol rol = new Rol
                {
                    RolId = rolId,
                    Nombre = pNombre
                };

                bool resultado = await rol.ModificarRolAsync(rol);
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
