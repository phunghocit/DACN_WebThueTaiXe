namespace API_3.Models
{
    public class datChuyenRequest
    {
        public int IDKhachHang { get; set; }
        public int? IDTongDaiVien { get; set; }
        public int? IDTaiXe { get; set; }
        public string DiemDon { get; set; }
        public DateTime? ThoiGianDon { get; set; }
        public string DiemKetThuc { get; set; }
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public decimal? GiaTien { get; set; }
        public string TrangThai { get; set; }
    }
}
