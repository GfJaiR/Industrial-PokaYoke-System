using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparacion2024
{
    class CompService
    {
        private static CompService _instance;

        public static CompService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompService();
                }
                return _instance;
            }
        }

        // Propiedades Booleanas
        public bool ComparacionPasta1Correcta { get; set; }
        public bool ComparacionPasta2Correcta { get; set; }
        public bool ComparacionStencilCorrecta { get; set; }

        // Propiedades de tipo String
        public string ComparacionPasta1 { get; set; }
        public string ComparacionPasta2 { get; set; }
        public string ComparacionStencil { get; set; }

        private CompService()
        {
            // Inicialización de las propiedades booleanas
            ComparacionPasta1Correcta = false;
            ComparacionPasta2Correcta = false;
            ComparacionStencilCorrecta = false;

            // Inicialización de las propiedades string
            ComparacionPasta1 = string.Empty;
            ComparacionPasta2 = string.Empty;
            ComparacionStencil = string.Empty;
        }
    }
}
