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
    
    public partial class tableGrupp
    {
        public tableGrupp()
        {
            this.tableBalli = new HashSet<tableBalli>();
            this.tablePrinadlegnistDisciplin = new HashSet<tablePrinadlegnistDisciplin>();
            this.tableZanyatiy = new HashSet<tableZanyatiy>();
            this.tableStudents = new HashSet<tableStudents>();
        }
    
        public int ID { get; set; }
        public int IDFacultet { get; set; }
        public string Name { get; set; }
        public int IDProfile { get; set; }
    
        public virtual ICollection<tableBalli> tableBalli { get; set; }
        public virtual tableFacultet tableFacultet { get; set; }
        public virtual ICollection<tablePrinadlegnistDisciplin> tablePrinadlegnistDisciplin { get; set; }
        public virtual ICollection<tableZanyatiy> tableZanyatiy { get; set; }
        public virtual tableProfile tableProfile { get; set; }
        public virtual ICollection<tableStudents> tableStudents { get; set; }
    }
}