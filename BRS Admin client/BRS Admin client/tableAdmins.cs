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
    
    public partial class tableAdmins
    {
        public int ID { get; set; }
        public int Role_ID { get; set; }
        public int Facultet_ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual tableRoles tableRoles { get; set; }
        public virtual tableFacultet tableFacultet { get; set; }
    }
}