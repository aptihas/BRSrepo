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
    
    public partial class tablePrinadlegnistDisciplin
    {
        public int ID { get; set; }
        public int ID_Facultet { get; set; }
        public int ID_Gruppi { get; set; }
        public int ID_Disciplini { get; set; }
        public int ID_Prepoda { get; set; }
        public int Otchetnost { get; set; }
        public int KR_KP { get; set; }
        public int ChasiDisciplini { get; set; }
    
        public virtual tableDisciplin tableDisciplin { get; set; }
        public virtual tableFacultet tableFacultet { get; set; }
        public virtual tableGrupp tableGrupp { get; set; }
    }
}
