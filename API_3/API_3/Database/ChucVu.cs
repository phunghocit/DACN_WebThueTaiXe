// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace API_3.Database
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        public int IDChucVu { get; set; }
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}