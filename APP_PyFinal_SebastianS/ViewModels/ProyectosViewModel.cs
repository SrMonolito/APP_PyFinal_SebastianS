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

        public ProyectosViewModel() { 
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

    }
}
