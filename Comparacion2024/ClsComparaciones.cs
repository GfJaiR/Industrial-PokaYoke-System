using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparacion2024
{
    class ClsComparaciones
    {
        public bool AgregarComparaciones(int NoEmpleado, string Linea, string Pasta1, string Pasta2, string Stencil, DateTime Fecha, string Comparacion)
        {
            MPM_COMPARACIONES NuevaComparacion = new MPM_COMPARACIONES();
            using (BDLogin db = new BDLogin())
            {

                NuevaComparacion.NO_EMPLEADO = NoEmpleado;
                NuevaComparacion.LINEA = Linea;
                NuevaComparacion.PASTA1 = Pasta1;
                NuevaComparacion.PASTA2 = Pasta2;
                NuevaComparacion.STENCIL = Stencil;
                NuevaComparacion.FECHA = Fecha;
                NuevaComparacion.IGUALES = Comparacion;

                //AgregarComparacion
                db.MPM_COMPARACIONES.Add(NuevaComparacion);
                return db.SaveChanges() > 0;
            }
        }
    }
}
