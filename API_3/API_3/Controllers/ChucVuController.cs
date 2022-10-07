using API_3.Database;
using API_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_3.Controllers
{
    // Lấy tên link
    [Route("api/[controller]")]
    [ApiController]

    public class ChucVuController : Controller
    {
        private readonly thuetaixeDbContext _context;
        
        public ChucVuController (thuetaixeDbContext context)
        {
            _context = context;
        }

        // Lấy toàn bộ chức vụ
        [HttpGet]
        public async Task<IActionResult> getChucVus()
        {
            return Ok(await _context.ChucVus.ToListAsync());
        }

        // Lấy 1 chức vụ
        [HttpGet]
        [Route("{IDChucVu:int}")]
        public async Task<IActionResult> getChucVu([FromRoute] int IDChucVu)
        {
            var idchucvu = _context.ChucVus.Find(IDChucVu);

            if (idchucvu == null)
            {
                return NotFound();
            }
            return Ok(idchucvu);
        }
       
        //Thêm chức vụ
        [HttpPost]
        public async Task<IActionResult> addChucVu(chucVuRequest request)
        {
            var chucVus = new ChucVu()
            {
                TenChucVu = request.TenChucVu,
                MoTa = request.MoTa
            };
            await _context.ChucVus.AddAsync(chucVus);
            await _context.SaveChangesAsync();
            return Ok(chucVus);
        }

        // Chỉnh sửa chức vụ
        [HttpPut]
        [Route("{IDChucVu:int}")]
        public async Task<IActionResult> updateChucVu([FromRoute] int IDChucVu, chucVuRequest request)
        {
            var idchucvu = _context.ChucVus.Find(IDChucVu);
            if (idchucvu != null)
            {
                idchucvu.TenChucVu = request.TenChucVu;
                idchucvu.MoTa = request.MoTa;

                await _context.SaveChangesAsync();
                return Ok(request);

            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{IDChucVu:int}")]
        public async Task<IActionResult> deleteChucVu([FromRoute] int IDChucVu)
        {
            var idchucvu = _context.ChucVus.Find(IDChucVu);
            
            if (idchucvu != null)
            {
                _context.Remove(idchucvu);
                await _context.SaveChangesAsync();
                return Ok(idchucvu);
            }
            return NotFound();
        }
    }
}
