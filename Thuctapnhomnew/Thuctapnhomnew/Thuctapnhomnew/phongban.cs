//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thuctapnhomnew
{
    using System;
    using System.Collections.Generic;
    
    public partial class phongban
    {
        public phongban()
        {
            this.nhanviens = new HashSet<nhanvien>();
        }
    
        public string ma { get; set; }
        public string ten { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<nhanvien> nhanviens { get; set; }
    }
}
