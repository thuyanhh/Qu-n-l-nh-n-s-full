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
    
    public partial class nhanvien
    {
        public nhanvien()
        {
            this.baohiems = new HashSet<baohiem>();
            this.luongnhanviens = new HashSet<luongnhanvien>();
        }
    
        public string ma { get; set; }
        public string ten { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public byte[] anh { get; set; }
        public string quequan { get; set; }
        public string noisinh { get; set; }
        public string hokhauthuongtru { get; set; }
        public string diachilienlac { get; set; }
        public string quoctich { get; set; }
        public string tongiao { get; set; }
        public string soCMT { get; set; }
        public Nullable<System.DateTime> ngaycap { get; set; }
        public string noicap { get; set; }
        public string noiohiennay { get; set; }
        public string dienthoai { get; set; }
        public string email { get; set; }
        public Nullable<bool> tinhtranghonnhan { get; set; }
        public string trinhdongoaingu { get; set; }
        public string hocvanma { get; set; }
        public string chucvuma { get; set; }
        public string phongbanma { get; set; }
        public string hopdonglaodongnhanvienma { get; set; }
        public string dantoc { get; set; }
    
        public virtual ICollection<baohiem> baohiems { get; set; }
        public virtual chucvu chucvu { get; set; }
        public virtual hocvan hocvan { get; set; }
        public virtual hopdonglaodongnhanvien hopdonglaodongnhanvien { get; set; }
        public virtual ICollection<luongnhanvien> luongnhanviens { get; set; }
        public virtual phongban phongban { get; set; }
        public virtual thongtinkhacvenhanvien thongtinkhacvenhanvien { get; set; }
    }
}
