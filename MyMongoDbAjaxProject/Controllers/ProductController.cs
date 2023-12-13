using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAjaxProject.DAL.Entities;
using MyMongoDbAjaxProject.DAL.Settings;

namespace MyMongoDbAjaxProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductController(IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values=await _productCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productCollection.InsertOneAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductID== id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values=await _productCollection.Find(x=>x.ProductID== id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == product.ProductID, product);
            return RedirectToAction("Index");
        }
    }
}
