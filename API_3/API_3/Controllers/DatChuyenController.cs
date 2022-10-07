using API_3.Database;
using API_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DatChuyenController : Controller
    {
        private readonly thuetaixeDbContext _context;

        public DatChuyenController(thuetaixeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getDatChuyen()
        {
            return Ok(await _context.DatChuyens.ToListAsync());
        }

        [HttpGet]
        [Route("{IDChuyen:int}")]
        public async Task<IActionResult> getDatChuyen([FromRoute] int IDChuyen)
        {
            var idc = _context.DatChuyens.Find(IDChuyen);

            if (idc == null)
            {
                return NotFound();
            }
            return Ok(idc);
        }

        [HttpPost]
        public async Task<IActionResult> addChuyen(datChuyenRequest request)
        {
            var dc = new DatChuyen()
            {
                IDKhachHang = request.IDKhachHang,
                IDTongDaiVien = request.IDTongDaiVien,
                IDTaiXe = request.IDTaiXe,
                DiemDon = request.DiemDon,
                ThoiGianDon = request.ThoiGianDon,
                DiemKetThuc = request.DiemKetThuc,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                ThoiGianKetThuc = request.ThoiGianKetThuc,
                TrangThai = request.TrangThai
            };
            await _context.DatChuyens.AddAsync(dc);
            await _context.SaveChangesAsync();
            return Ok(dc);
        }

        [HttpPut]
        [Route("{IDChuyen:int}")]
        public async Task<IActionResult> updateChuyen([FromRoute] int IDChuyen, datChuyenRequest request)
        {
            var idc = _context.DatChuyens.Find(IDChuyen);
            if (idc != null)
            {
                idc.IDKhachHang = request.IDKhachHang;
                idc.IDTongDaiVien = request.IDTongDaiVien;
                idc.IDTaiXe = request.IDTaiXe;
                idc.DiemDon = request.DiemDon;
                idc.ThoiGianDon = request.ThoiGianDon;
                idc.DiemKetThuc = request.DiemKetThuc;
                idc.Longitude = request.Longitude;
                idc.Latitude = request.Latitude;
                idc.ThoiGianKetThuc = request.ThoiGianKetThuc;
                idc.TrangThai = request.TrangThai;
                await _context.SaveChangesAsync();
                return Ok(request);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IDChuyen:int}")]
        public async Task<IActionResult> deleteChuyen([FromRoute] int IDChuyen)
        {
            var idc = _context.DatChuyens.Find(IDChuyen);

            if (idc != null)
            {
                _context.Remove(idc);
                await _context.SaveChangesAsync();
                return Ok(idc);
            }
            return NotFound();
        }
    }
}
