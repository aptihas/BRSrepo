//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BRSGSTOU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tableBalli
    {
        public int ID { get; set; }
        public int ID_Gruppi { get; set; }
        public int ID_Disciplini { get; set; }
        public int ID_prepoda { get; set; }
        public int ID_Studenta { get; set; }
        public int Pos1 { get; set; }
        public int Tek1 { get; set; }
        public int Rub1 { get; set; }
        public int Pos2 { get; set; }
        public int Tek2 { get; set; }
        public int Rub2 { get; set; }
        public int Samost { get; set; }
        public int Dosdacha { get; set; }
        public int Premial { get; set; }
        public int Itog { get; set; }
    
        public virtual tableDisciplin tableDisciplin { get; set; }
        public virtual tableGrupp tableGrupp { get; set; }
        public virtual tablePrepods tablePrepods { get; set; }
        public virtual tableStudents tableStudents { get; set; }
    }
}