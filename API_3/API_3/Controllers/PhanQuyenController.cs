using API_3.Database;
using API_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhanQuyenController : Controller
    {
        private readonly thuetaixeDbContext _context;
        
        public PhanQuyenController (thuetaixeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getPhanQuyens()
        {
            return Ok(await _context.PhanQuyens.ToListAsync());
        }

        [HttpGet]
        [Route("{IDQuyen:int}")]
        public async Task<IActionResult> getPhanQuyen([FromRoute] int IDQuyen)
        {
            var idQuyen = _context.PhanQuyens.Find(IDQuyen);

            if (idQuyen == null)
            {
                return NotFound();
            }
            return Ok(idQuyen);
        }

        [HttpPost]
        public async Task<IActionResult> addPhanQuyen(phanQuyenRequest request)
        {
            var quyen = new PhanQuyen()
            {
                IDChucVu = request.IDChucVu,
                TenQuyen = request.TenQuyen,
                MoTa = request.MoTa
            };
            await _context.PhanQuyens.AddAsync(quyen);
            await _context.SaveChangesAsync();
            return Ok(quyen);
        }

        [HttpPut]
        [Route("{IDQuyen:int}")]
        public async Task<IActionResult> updateQuyen([FromRoute] int IDQuyen, phanQuyenRequest request)
        {
            var idquyen = _context.PhanQuyens.Find(IDQuyen);
            if (idquyen != null)
            {
                idquyen.IDChucVu = request.IDChucVu;
                idquyen.TenQuyen = request.TenQuyen;
                idquyen.MoTa = request.MoTa;

                await _context.SaveChangesAsync();
                return Ok(request);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IDQuyen:int}")]
        public async Task<IActionResult> deleteQuyen([FromRoute] int IDQuyen)
        {
            var idQuyen = _context.PhanQuyens.Find(IDQuyen);

            if (idQuyen != null)
            {
                _context.Remove(idQuyen);
                await _context.SaveChangesAsync();
                return Ok(idQuyen);
            }
            return NotFound();
        }
    }
}
