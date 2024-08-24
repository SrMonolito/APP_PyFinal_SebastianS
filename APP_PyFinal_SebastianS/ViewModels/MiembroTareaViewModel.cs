using APP_PyFinal_SebastianS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PyFinal_SebastianS.ViewModels
{
    public class MiembroTareaViewModel : BaseViewModel
    {

        public MiembroTarea MyMiembroTarea { get; set; }

        public MiembroTareaViewModel()
        {
            MyMiembroTarea = new MiembroTarea();
        }

        //Funcion que carga los miembtarea para mostrar en la tableview
        public async Task<List<MiembroTarea>?> VmGetMiembroTareasAsync()
        {
            try
            {
                List<MiembroTarea>? miembtarea = new List<MiembroTarea>();
                miembtarea = await MyMiembroTarea.GetMiembroTareasAsync();
                if (miembtarea == null) return null;

                return miembtarea;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VmAddMiembroTarea(
                                              int pMiembroId,
                                              int pTareaId
            )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyMiembroTarea = new()
                {
                    MiembroId = pMiembroId,
                    TareaId = pTareaId
                };
                bool Ret = (bool)await MyMiembroTarea.AddMiembroTareaAsync();
                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<MiembroTarea?> VmBuscarMiembroTareaByIdAsync(int miembtareaId)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                MiembroTarea? miembtarea = await MyMiembroTarea.BuscarMiembroTareaByIdAsync(miembtareaId);
                if (miembtarea != null)
                {
                    MyMiembroTarea = miembtarea;
                }
                return miembtarea;
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

        public async Task<bool> VmModificarMiembroTareaAsync(int pMiembTareaId,
                                                         int pMiembroId,
                                                         int pTareaId)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiembroTarea miembtarea = new MiembroTarea
                {
                    MiembTareaId = pMiembTareaId,
                    MiembroId = pMiembroId,
                    TareaId = pTareaId
                };

                bool resultado = await miembtarea.ModificarMiembroTareaAsync(miembtarea);
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
