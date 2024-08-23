using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_PyFinal_SebastianS.Models;

namespace APP_PyFinal_SebastianS.ViewModels
{
    public class ProyectosViewModel : BaseViewModel
    {
        public Proyecto MyProyecto { get; set; }

        public ProyectosViewModel()
        {
            MyProyecto = new Proyecto();
        }

        //Funcion que carga los proyectos para mostrar en la tableview
        public async Task<List<Proyecto>?> VmGetProyectosAsync()
        {
            try
            {
                List<Proyecto>? proyectos = new List<Proyecto>();
                proyectos = await MyProyecto.GetProyectosAsync();
                if (proyectos == null) return null;

                return proyectos;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VmAddProyecto(string pNombre,
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
                MyProyecto = new()
                {
                    Nombre = pNombre,
                    Descripcion = pDescripcion,
                    FechaInicio = pFechaInicio,
                    FechaFin = pFechaFin,
                    Estado = pEstado
                };
                bool Ret = (bool)await MyProyecto.AddProyectoAsync();
                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<Proyecto?> VmBuscarProyectoByIdAsync(int proyectoId)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                Proyecto? proyecto = await MyProyecto.BuscarProyectoByIdAsync(proyectoId);
                if (proyecto != null)
                {
                    MyProyecto = proyecto;
                }
                return proyecto;
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

        public async Task<bool> VmModificarProyectoAsync(int proyectoId,
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
                Proyecto proyecto = new Proyecto
                {
                    ProyectoId = proyectoId,
                    Nombre = pNombre,
                    Descripcion = pDescripcion,
                    FechaInicio = pFechaInicio,
                    FechaFin = pFechaFin,
                    Estado = pEstado
                };

                bool resultado = await proyecto.ModificarProyectoAsync(proyecto);
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
