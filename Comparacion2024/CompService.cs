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

        public bool ComparacionPasta1Correcta { get; set; }
        public bool ComparacionPasta2Correcta { get; set; }
        public bool ComparacionStencilCorrecta { get; set; }

        private CompService()
        {
            ComparacionPasta1Correcta = false;
            ComparacionPasta2Correcta = false;
            ComparacionStencilCorrecta = false;
        }
    }
}
