using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comparacion2024
{
    class MPM_COMPARACIONES
    {
       
            [Key]
            public int ID_REGISTRO { get; set; }
            public int NO_EMPLEADO { get; set; }
            public string LINEA { get; set; }
            public string PASTA1 { get; set; }
            public string PASTA2 { get; set; }
            public string STENCIL { get; set; }
            public DateTime FECHA { get; set; }
            public string IGUALES { get; set; }
            //public int ID_LINEA { get; set; }
    }
}
