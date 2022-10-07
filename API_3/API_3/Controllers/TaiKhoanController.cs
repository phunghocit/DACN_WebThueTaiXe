using API_3.Database;
using API_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaiKhoanController : Controller
    {
        private readonly thuetaixeDbContext _context;

        public TaiKhoanController(thuetaixeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getTaiKhoans()
        {
            return Ok(await _context.TaiKhoans.ToListAsync());
        }

        [HttpGet]
        [Route("{IDTaiKhoan:int}")]
        public async Task<IActionResult> getTaiKhoan([FromRoute] int IDTaiKhoan)
        {
            var idtk = _context.TaiKhoans.Find(IDTaiKhoan);

            if (idtk == null)
            {
                return NotFound();
            }
            return Ok(idtk);
        }

        [HttpPost]
        public async Task<IActionResult> addTaiKhoan(taiKhoanReuqest request)
        {
            var taikhoan = new TaiKhoan()
            {
                TenTaiKhoan = request.TenTaiKhoan,
                MatKhau = request.MatKhau,
                TrangThai = request.TrangThai,
                Token = request.Token
            };
            await _context.TaiKhoans.AddAsync(taikhoan);
            await _context.SaveChangesAsync();
            return Ok(taikhoan);
        }

        [HttpPut]
        [Route("{IDTaiKhoan:int}")]
        public async Task<IActionResult> updateTaiKhoan([FromRoute] int IDTaiKhoan, taiKhoanReuqest request)
        {
            var idtk = _context.TaiKhoans.Find(IDTaiKhoan);
            if (idtk != null)
            {
                idtk.TenTaiKhoan = request.TenTaiKhoan;
                idtk.MatKhau = request.MatKhau;
                idtk.TrangThai= request.TrangThai;
                idtk.Token = request.Token;

                await _context.SaveChangesAsync();
                return Ok(request);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IDTaiKhoan:int}")]
        public async Task<IActionResult> deleteTaiKhoan([FromRoute] int IDTaiKhoan)
        {
            var idtk = _context.TaiKhoans.Find(IDTaiKhoan);

            if (idtk != null)
            {
                _context.Remove(idtk);
                await _context.SaveChangesAsync();
                return Ok(idtk);
            }
            return NotFound();
        }
    }
}
