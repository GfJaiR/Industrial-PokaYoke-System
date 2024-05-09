using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrypt;
namespace Comparacion2024
{
    class UsuarioManager
    {
        private UsuarioRepository _repository = new UsuarioRepository();
        public bool AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            // Verificar las credenciales llamando al método de la capa de acceso a datos
            return _repository.VerificarCredenciales(nombreUsuario, contraseña);
        }
        public bool AgregarUsuario(string nombreUsuario, string contraseña, bool esAdministrador)
        {
            // Crear una instancia del encoder Scrypt
            ScryptEncoder encoder = new ScryptEncoder();

            // Crear un nuevo usuario con la contraseña ya hasheada
            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                ContraseñaHash = encoder.Encode(contraseña), // Hashear aquí
                                                             // otros campos necesarios
            };

            // Pasar el usuario al repository para guardarlo
            return _repository.AgregarUsuario(nuevoUsuario, esAdministrador);
        }
    }
}
