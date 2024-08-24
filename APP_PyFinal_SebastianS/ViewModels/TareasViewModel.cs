using APP_PyFinal_SebastianS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PyFinal_SebastianS.ViewModels
{
    public class TareasViewModel : BaseViewModel
    {

        public Tarea MyTarea { get; set; }

        public TareasViewModel()
        {
            MyTarea = new Tarea();
        }

        //Funcion que carga los tareas para mostrar en la tableview
        public async Task<List<Tarea>?> VmGetTareaAsync()
        {
            try
            {
                List<Tarea>? tareas = new List<Tarea>();
                tareas = await MyTarea.GetTareasAsync();
                if (tareas == null) return null;

                return tareas;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VmAddTarea(
            int pProyectoId,
            string pNombre,
                                              string pDescripcion,
                                              DateOnly pFechaInicio,
                                              DateOnly pFechaFin,
                                              string pEstado
            )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyTarea = new()
                {
                    Nombre = pNombre,
                    Descripcion = pDescripcion,
                    FechaInicio = pFechaInicio,
                    FechaFin = pFechaFin,
                    Estado = pEstado
                };
                bool Ret = (bool)await MyTarea.AddTareaAsync();
                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<Tarea?> VmBuscarTareaByIdAsync(int tareaId)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                Tarea? tarea = await MyTarea.BuscarTareaByIdAsync(tareaId);
                if (tarea != null)
                {
                    MyTarea = tarea;
                }
                return tarea;
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

        public async Task<bool> VmModificarTareaAsync(int tareaId,
            int pProyectoId,
                                                         string pNombre,
                                                         string pDescripcion,
                                                         DateOnly pFechaInicio,
                                                         DateOnly pFechaFin,
                                                         string pEstado)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                Tarea tarea = new Tarea
                {
                    TareaId = tareaId,
                    ProyectoId = pProyectoId,
                    Nombre = pNombre,
                    Descripcion = pDescripcion,
                    FechaInicio = pFechaInicio,
                    FechaFin = pFechaFin,
                    Estado = pEstado
                };

                bool resultado = await tarea.ModificarTareaAsync(tarea);
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
