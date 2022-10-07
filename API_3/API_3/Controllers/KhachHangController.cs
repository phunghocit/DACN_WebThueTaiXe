using API_3.Database;
using API_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace API_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class KhachHangController : Controller
    {
        private readonly thuetaixeDbContext _context;

        public KhachHangController (thuetaixeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getKhachHangs()
        {
            return Ok(await _context.KhachHangs.ToListAsync());
        }

        [HttpGet]
        [Route("{IDKhachHang:int}")]
        public async Task<IActionResult> getKhachHang([FromRoute] int IDKhachHang)
        {
            var idkh = _context.KhachHangs.Find(IDKhachHang);

            if (idkh == null)
            {
                return NotFound();
            }
            return Ok(idkh);
        }

        [HttpPost]
        public async Task<IActionResult> addKhachHang(khachHangRequest request)
        {
            var kh = new KhachHang()
            {
                IDTaiKhoan = request.IDTaiKhoan,
                HoTen = request.HoTen,
                DienThoai = request.DienThoai,
                DiaChi = request.DiaChi,
                Image  = request.Image,
                Longitude = request.Longitude,
                Latitude = request.Latitude
            };
            await _context.KhachHangs.AddAsync(kh);
            await _context.SaveChangesAsync();
            return Ok(kh);
        }

        [HttpPut]
        [Route("{IDKhachHang:int}")]
        public async Task<IActionResult> updateKhachHang([FromRoute] int IDKhachHang, khachHangRequest request)
        {
            var idkh = _context.KhachHangs.Find(IDKhachHang);
            if (idkh != null)
            {
                idkh.IDTaiKhoan = request.IDTaiKhoan;
                idkh.HoTen = request.HoTen;
                idkh.DienThoai = request.DienThoai;
                idkh.DiaChi = request.DiaChi;
                idkh.Image = request.Image;
                idkh.Longitude = request.Longitude;
                idkh.Latitude = request.Latitude;
                await _context.SaveChangesAsync();
                return Ok(request);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IDKhachHang:int}")]
        public async Task<IActionResult> deleteKhachHang([FromRoute] int IDKhachHang)
        {
            var idkh = _context.KhachHangs.Find(IDKhachHang);

            if (idkh != null)
            {
                _context.Remove(idkh);
                await _context.SaveChangesAsync();
                return Ok(idkh);
            }
            return NotFound();
        }
    }
}
