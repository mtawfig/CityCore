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
    
    public partial class PROJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJECT()
        {
            this.PROJECT_TASK = new HashSet<PROJECT_TASK>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string ADM_ID { get; set; }
        public string FILE_NAME { get; set; }
        public string LANDLORD { get; set; }
        public string TENANT_NAME { get; set; }
        public string PROPERTY_MNGR { get; set; }
        public string AREA { get; set; }
        public string SECTOR { get; set; }
        public string PLOT { get; set; }
        public string UNIT_NO { get; set; }
        public Nullable<int> PROJECT_MGR { get; set; }
        public Nullable<int> MANAGING_DIRECTOR { get; set; }
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
        public virtual EMPLOYEE EMPLOYEE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROJECT_TASK> PROJECT_TASK { get; set; }

        //public static implicit operator PROJECT(PROJECT v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
