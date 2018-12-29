//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CityCore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROJECT_TASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJECT_TASK()
        {
            this.PROJECT_TASK_DOC = new HashSet<PROJECT_TASK_DOC>();
        }
    
        public int ID { get; set; }
        public Nullable<int> PROJECT_ID { get; set; }
        public Nullable<int> TASK_ID { get; set; }
        public Nullable<int> ASSIGNED_TO { get; set; }
        public string STATUS { get; set; }
        public string NOTES { get; set; }
        public Nullable<int> COMPANY_ID { get; set; }
        public Nullable<int> CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<int> UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<bool> IS_DELETED { get; set; }
        public Nullable<int> DELETE_BY { get; set; }
        public Nullable<System.DateTime> DELETE_DATE { get; set; }
    
        public virtual COMPANY COMPANY { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual PROJECT PROJECT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROJECT_TASK_DOC> PROJECT_TASK_DOC { get; set; }
        public virtual TASK TASK { get; set; }
    }
}