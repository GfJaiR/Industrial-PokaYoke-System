using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Comparacion2024
{
    class Stenciles
    {
            [Key]
            public int RegistroID { get; set; }
            public string UserID { get; set; }
            public string ReelID { get; set; }
            public string PartNo { get; set; }
            public int Quantity { get; set; }

    }
}
