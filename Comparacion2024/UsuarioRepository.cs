using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Comparacion2024
{
    class UsuarioRepository
    {
        /* string nombreUsuarioAutenticado = "nombreDeUsuario"; */// Reemplaza esto con el nombre de usuario real
        public bool VerificarCredenciales(string nombreUsuario, string contraseña)
        {
            using (BDLogin db = new BDLogin())
            {
                var usuario = db.Usuarios
                                .Where(u => u.NombreUsuario == nombreUsuario)
                                .FirstOrDefault();

                if (usuario != null)
                {
                    // Verifica la contraseña utilizando BCrypt
                    return HashHelper.VerificarHash(contraseña, usuario.ContraseñaHash);
                }

                return false;
            }
        }

        public int? ObtenerRolIdUsuario(string nombreUsuario)
        {
            using (BDLogin db = new BDLogin())
            {
                var rolIdUsuario = db.Usuarios
                                     .Where(u => u.NombreUsuario == nombreUsuario)
                                     .Select(u => u.RolID)
                                     .FirstOrDefault();

                return rolIdUsuario;
            }
        }

        public bool AgregarUsuario(Usuario usuario, bool esAdministrador)
        {
            using (BDLogin db = new BDLogin())
            {
                // Asignar el RolID según la lógica de roles
                int rolID = esAdministrador ? 1 : 2;

                // Asignar el RolID al usuario
                usuario.RolID = rolID;

                // Agregar el usuario a la tabla Usuarios
                db.Usuarios.Add(usuario);
                return db.SaveChanges() > 0;
            }
        }
    }
}
