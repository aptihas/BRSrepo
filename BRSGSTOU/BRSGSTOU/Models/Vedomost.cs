using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRSGSTOU.Models
{
    public class Vedomost
    {
        public string StudentName { get; set; }
        public int Student_ID { get; set; }
        public byte DopuskKSessii { get; set; }
        public string NomerZachetki { get; set; }
        public int Pos1 { get; set; }
        public int Tek1 { get; set; }
        public int Rub1 { get; set; }
        public int Pos2 { get; set; }
        public int Tek2 { get; set; }
        public int Rub2 { get; set; }
        public int Samost { get; set; }
        public int Dosdacha { get; set; }
        public int Premial { get; set; }
        public int Itog {
            get {

                return Itog = Pos1 + Tek1 + Rub1 + Pos2 + Tek2 + Rub2 + Samost + Dosdacha + Premial;
            } 
            set { 
                 
            } 
        }
    }
}