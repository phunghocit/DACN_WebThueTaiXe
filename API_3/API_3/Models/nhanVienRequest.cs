namespace API_3.Models
{
    public class nhanVienRequest
    {
        public int? IDQuyen { get; set; }
        public int? IDChucVu { get; set; }
        public int? IDTaiKhoan { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Image { get; set; }
        public int? Longitude { get; set; }
        public int? Latiude { get; set; }
    }
}
