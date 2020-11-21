using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCRUD.Models
{
    public class myStudents
    {
        public int Student_Id { get; set; }

        [Required(ErrorMessage ="Please Enter Name of Student")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Name of Student Address")]
        public string Address { get; set; }

        
        public Nullable<int> Class_Id { get; set; }

        public virtual myClassInfo ClassInfo { get; set; }
    }
}