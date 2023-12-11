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
        public IActionResult Index()
        {
            return View();
        }
    }
}
