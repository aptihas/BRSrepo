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
    
    public partial class tableProfile
    {
        public tableProfile()
        {
            this.tableGrupp = new HashSet<tableGrupp>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tableGrupp> tableGrupp { get; set; }
    }
}
