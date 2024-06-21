using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Comparacion2024
{
    class ClsStenciles
    {
        public bool AgregarStencil(string userid, string reelid, string partno, int qu)
        {
            Stenciles NuevoStencil = new Stenciles();
            using (BDLogin db = new BDLogin())
            {
                // Asignar el RolID al usuario
                NuevoStencil.UserID = userid;
                NuevoStencil.ReelID = reelid;
                NuevoStencil.PartNo = partno;
                NuevoStencil.Quantity = qu;
                // Agregar el usuario a la tabla Usuarios
                db.Stenciles.Add(NuevoStencil);
                return db.SaveChanges() > 0;
            
            }
        }
        public void DisminuirCantidad(string numerodeparte)
        {
            // Verificar si hay al menos un número de parte
          
                string query = "UPDATE Reels SET Quantity = Quantity - 1 WHERE PartNo = @partNo";
                string connection = "Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true";

                using (SqlConnection connectionstring = new SqlConnection(connection))
                {
                    // Abrir la conexión
                    connectionstring.Open();

                    // Crear y ejecutar el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connectionstring))
                    {
                        // Agregar parámetros para cada número de parte
                        
                            command.Parameters.AddWithValue("@partNo", numerodeparte);
                            // Ejecutar el comando para cada número de parte
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                //MessageBox.Show("Cantidad actualizada correctamente para el número de parte: " + numerodeparte);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar la cantidad para el número de parte: " + numerodeparte);
                            }
                           
                        
                    }
                }
            
           
        }
    }
}
