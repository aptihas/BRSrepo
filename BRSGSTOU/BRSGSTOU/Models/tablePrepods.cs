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
    
    public partial class tablePrepods
    {
        public tablePrepods()
        {
            this.tableBalli = new HashSet<tableBalli>();
            this.tableZanyatiy = new HashSet<tableZanyatiy>();
            this.teachersAccounts = new HashSet<teachersAccounts>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tableBalli> tableBalli { get; set; }
        public virtual ICollection<tableZanyatiy> tableZanyatiy { get; set; }
        public virtual ICollection<teachersAccounts> teachersAccounts { get; set; }
    }
}
