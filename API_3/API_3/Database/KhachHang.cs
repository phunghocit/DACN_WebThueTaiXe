﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace API_3.Database
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DatChuyens = new HashSet<DatChuyen>();
        }

        public int IDKhachHang { get; set; }
        public int IDTaiKhoan { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Image { get; set; }
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }

        public virtual TaiKhoan IDTaiKhoanNavigation { get; set; }
        public virtual ICollection<DatChuyen> DatChuyens { get; set; }
    }
}