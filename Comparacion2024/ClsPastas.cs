using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Comparacion2024
{
	class ClsPastas
	{
		public bool AgregarPasta(string userid, string reelid, string partno, int qu, int lc)
		{
            Pastas NuevaPasta = new Pastas();
            using (BDLogin db = new BDLogin())
            {
                // Asignar las variables recibidas por el constructor al modelo de Pasta
                NuevaPasta.UserID = userid;
                NuevaPasta.ReelID = reelid;
                NuevaPasta.PartNo = partno;
                NuevaPasta.Quantity = qu;
                NuevaPasta.LastQuantitySet = lc;
                // Agregar la pasta y guardar
                db.Pastas.Add(NuevaPasta);
                return db.SaveChanges() > 0;

            }
        }
	}
}
