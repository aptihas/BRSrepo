//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BRS_Admin_client
{
    using System;
    using System.Collections.Generic;
    
    public partial class tableRoles
    {
        public tableRoles()
        {
            this.tableAdmins = new HashSet<tableAdmins>();
            this.teachersAccounts = new HashSet<teachersAccounts>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tableAdmins> tableAdmins { get; set; }
        public virtual ICollection<teachersAccounts> teachersAccounts { get; set; }
    }
}
