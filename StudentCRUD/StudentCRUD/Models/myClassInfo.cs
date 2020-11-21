using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentCRUD.Models
{
    public class myClassInfo
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public myClassInfo()
        {
            this.Students = new HashSet<myStudents>();
        }

        
        public int Class_Id { get; set; }
        [DisplayName("Standard")]
        public Nullable<int> Standard { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<myStudents> Students { get; set; }
    }
}