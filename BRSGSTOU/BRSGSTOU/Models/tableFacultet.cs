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
    
    public partial class tableFacultet
    {
        public tableFacultet()
        {
            this.tableAdmins = new HashSet<tableAdmins>();
            this.tableGrupp = new HashSet<tableGrupp>();
            this.tablePrinadlegnistDisciplin = new HashSet<tablePrinadlegnistDisciplin>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tableAdmins> tableAdmins { get; set; }
        public virtual ICollection<tableGrupp> tableGrupp { get; set; }
        public virtual ICollection<tablePrinadlegnistDisciplin> tablePrinadlegnistDisciplin { get; set; }
    }
}
