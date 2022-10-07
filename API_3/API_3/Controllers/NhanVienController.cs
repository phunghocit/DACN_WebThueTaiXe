using API_3.Database;
using API_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NhanVienController : Controller
    {
        private readonly thuetaixeDbContext _context;

        public NhanVienController(thuetaixeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getNhanViens()
        {
            return Ok(await _context.NhanViens.ToListAsync());
        }

        [HttpGet]
        [Route("{IDNhanVien:int}")]
        public async Task<IActionResult> getNhanVien([FromRoute] int IDNhanVien)
        {
            var idnv = _context.NhanViens.Find(IDNhanVien);

            if (idnv == null)
            {
                return NotFound();
            }
            return Ok(idnv);
        }

        [HttpPost]
        public async Task<IActionResult> addKhachHang(nhanVienRequest request)
        {
            var nv = new NhanVien()
            {
                IDQuyen = request.IDQuyen,
                IDChucVu = request.IDChucVu,
                IDTaiKhoan = request.IDTaiKhoan,
                HoTen = request.HoTen,
                DienThoai = request.DienThoai,
                DiaChi = request.DiaChi,
                Image = request.Image,
                Longitude = request.Longitude,
                Latiude = request.Latiude
            };
            await _context.NhanViens.AddAsync(nv);
            await _context.SaveChangesAsync();
            return Ok(nv);
        }

        [HttpPut]
        [Route("{IDNhanVien:int}")]
        public async Task<IActionResult> updateNhanVien([FromRoute] int IDNhanVien, nhanVienRequest request)
        {
            var idnv = _context.NhanViens.Find(IDNhanVien);
            if (idnv != null)
            {
                idnv.IDQuyen = request.IDQuyen;
                idnv.IDChucVu = request.IDChucVu;
                idnv.IDTaiKhoan = request.IDTaiKhoan;
                idnv.HoTen = request.HoTen;
                idnv.DienThoai = request.DienThoai;
                idnv.DiaChi = request.DiaChi;
                idnv.Image = request.Image;
                idnv.Longitude = request.Longitude;
                idnv.Latiude = request.Latiude;
                await _context.SaveChangesAsync();
                return Ok(request);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IDNhanVien:int}")]
        public async Task<IActionResult> deleteNhanVien([FromRoute] int IDNhanVien)
        {
            var idnv = _context.NhanViens.Find(IDNhanVien);

            if (idnv != null)
            {
                _context.Remove(idnv);
                await _context.SaveChangesAsync();
                return Ok(idnv);
            }
            return NotFound();
        }
    }
}
