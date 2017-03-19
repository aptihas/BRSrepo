using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRSGSTOU.Models
{
    public class ModelZanyatiy
    {
        public int ID_Gruppi { get; set; }
        public int ID_Disciplini { get; set; }
        public int ID_Prepoda { get; set; }
        public int ID_Zanyatiya { get; set; }
        public int ID_Studenta { get; set; }
        public byte Otmetka { get; set; }
        public System.DateTime Vremya { get; set; }
    }
}