using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Services;

namespace PurchaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataProviderService _dataProviderService;

        public ProductsController(
            IDataProviderService dataProviderService
        )
        {
            _dataProviderService = dataProviderService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _dataProviderService.GetProducts();
        }

        [HttpGet("{index}")]
        public string Get(int index)
        {
            return _dataProviderService.GetProduct(index);
        }

        [HttpPost]
        public string Create([FromBody] string name)
        {
            return _dataProviderService.CreateProduct(name);
        }

        [HttpPut("{index}")]
        public string Update(int index, string name)
        {
            return _dataProviderService.UpdateProduct(index, name);
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            _dataProviderService.DeleteProduct(index);
        }
    }
}