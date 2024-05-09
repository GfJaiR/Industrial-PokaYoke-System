using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Comparacion2024
{
    class ClsConex
    {
        private SqlConnection conexion;

     
       public ClsConex()
        {
            string connectionString = "Data Source=TuServidor;Initial Catalog=TuBaseDeDatos;Integrated Security=True";
            conexion = new SqlConnection(connectionString);
        }
          
           
            
        

    }
}
