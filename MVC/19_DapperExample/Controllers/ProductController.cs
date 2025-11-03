using _19_DapperExample.Data;
using _19_DapperExample.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace _19_DapperExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly DapperContext _context;
        public ProductController(DapperContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var query = "Select * from Products p inner join Categories c on p.CategoryId=c.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                //Dapper ile çoklu tablo sorgulama
                var products = await connection.QueryAsync<Product, Category, Product>(
                    query,
                    (product, category) =>
                    {
                        product.Category=category;
                        return product;
                    },
                    splitOn: "CategoryId"//Kategorileri ayırmak için kullanılan sütun
                    );
                return View(products.ToList());
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var query = "Insert into Products (Name,Price,CategoryId) values (@Name,@Price,@CategoryId)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
                if (product==null)
                {
                    return NotFound();
                }
                return View(product);

            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            var query = "Update Products Set Name=@Name,Price=@Price,CategoryId=@CategoryId where ProductId=@ProductId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, product);
                return RedirectToAction("Index");
            }

        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
                if (product==null)
                {
                    return NotFound("Ürün bulunamadı");
                }
                return View(product);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = "Delete From Products where ProductId=@Id";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, new { Id = id });
                if (result>0)
                {
                    ViewBag.Message="Product Delete Successfully";
                }
                else
                {
                    ViewBag.Message="Product Delete Failed";
                }
                return View("DeleteResult");
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
                if (product==null)
                {
                    return NotFound("Product Bulunamadı");
                }
                return View(product);
            }
        }
    }
}
