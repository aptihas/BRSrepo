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
    
    public partial class tableDisciplin
    {
        public tableDisciplin()
        {
            this.tableBalli = new HashSet<tableBalli>();
            this.tablePrinadlegnistDisciplin = new HashSet<tablePrinadlegnistDisciplin>();
            this.tableZanyatiy = new HashSet<tableZanyatiy>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tableBalli> tableBalli { get; set; }
        public virtual ICollection<tablePrinadlegnistDisciplin> tablePrinadlegnistDisciplin { get; set; }
        public virtual ICollection<tableZanyatiy> tableZanyatiy { get; set; }
    }
}
