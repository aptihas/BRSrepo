using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRSGSTOU.Models
{
    public class TeachersData
    {
        public int Gruppa_ID { get; set; }
        public string Gruppa { get; set; }
        public int Prepod_ID { get; set; }
        public string Prepod { get; set; }
        public int Facultet_ID { get; set; }
        public string Facultet { get; set; }
        public int Disciplina_ID { get; set; }
        public string Disciplina { get; set; }
        public int prinadlegnostDisciplin_ID { get; set; }
    }
}