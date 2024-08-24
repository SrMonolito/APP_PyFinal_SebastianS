
using APP_PyFinal_SebastianS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PyFinal_SebastianS.ViewModels
{
    internal class ComentarioViewModel : BaseViewModel
    {

        public Comentario MyComentario { get; set; }

        public ComentarioViewModel()
        {
            MyComentario = new Comentario();
        }

        //Funcion que carga los comentarios para mostrar en la tableview
        public async Task<List<Comentario>?> VmGetComentariosAsync()
        {
            try
            {
                List<Comentario>? comentarios = new List<Comentario>();
                comentarios = await MyComentario.GetComentariosAsync();
                if (comentarios == null) return null;

                return comentarios;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VmAddComentario(int pTareaId,
                                              int pMiembroId,
                                              DateOnly pFecha,
                                              string pComentario
            )
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyComentario = new()
                {
                    TareaId = pTareaId,
                    MiembroId = pMiembroId,
                    Fecha = pFecha,
                    Comentariotxt = pComentario
                };
                bool Ret = (bool)await MyComentario.AddComentarioAsync();
                return Ret;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<Comentario?> VmBuscarComentarioByIdAsync(int proyectoId)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                Comentario? proyecto = await MyComentario.BuscarComentarioByIdAsync(proyectoId);
                if (proyecto != null)
                {
                    MyComentario = proyecto;
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

        public async Task<bool> VmModificarComentarioAsync(int ComentarioId,
                                                         int pTareaId,
                                              int pMiembroId,
                                              DateOnly pFecha,
                                              string pComentario)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                Comentario proyecto = new Comentario
                {
                    ComentarioId = ComentarioId,
                    TareaId = pTareaId,
                    MiembroId = pMiembroId,
                    Fecha = pFecha,
                    Comentariotxt = pComentario
                };

                bool resultado = await proyecto.ModificarComentarioAsync(proyecto);
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
