using _16_WebApi.DataContext;
using _16_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _16_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context= context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (_context.Products.Count()>0)
            {
                var totalCount = await _context.Products.CountAsync();
                var products = await _context.Products.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
                //Sayfalama işlemi sayfa numarasına göre atlanması gereken ürün sayısını hesaplar
                //Take belirtilen sayıda ürünü alır
                //Listeyi asenkron olarak alır

                Response.Headers.Add("X-Total-Count", totalCount.ToString());//Toplam ürün sayısını headerda gönderiyoruz
                Response.Headers.Add("X-Page", page.ToString());//Mevcut sayfayı Headerda gönderiyoruz
                Response.Headers.Add("X-Page-Size", pageSize.ToString());//Sayfa başına düşen ürün sayısını Headerda gönderiyoruz
                return products;
            }
            return NotFound("Ürün Bulunamadı");//404 hatası dönderecek  
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400 hatası
            }
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ürün eklenirken bir hata oluştu: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id!=product.Id)
            {
                return BadRequest("Ürün ID'si eşleşmiyor.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Entry(product).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductExists(id))
                {
                    return NotFound("Güncellenmek istenen ürün bulunamadı.");
                }
                else
                {
                    return StatusCode(500, $"Ürün güncellenirken bir hata oluştu: {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ürün güncellenirken bir hata oluştu: {ex.Message}");
            }
            return NoContent();//Başarılı durumda 204 döner
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product==null)
                {
                    return NotFound("Ürün bulunamadı");
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok($"Id: {id} olan ürün başarıyla silindi");//200
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ürün silinirken hata oluştu: "+ex.Message);
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id==id);
        }

    }
}
