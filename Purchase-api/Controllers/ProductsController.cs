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
        public ActionResult<string> Get(int index)
        {
            try
            {
                return _dataProviderService.GetProduct(index);
            }
            catch(ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public string Create([FromBody] string name)
        {
            return _dataProviderService.CreateProduct(name);
        }

        [HttpPut("{index}")]
        public ActionResult<string> Update(int index, string name)
        {
            try
            {
                return _dataProviderService.UpdateProduct(index, name);
            }
            catch(ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            try
            {
                _dataProviderService.DeleteProduct(index);
                return Ok("Product deleted");
            }
            catch(ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }
    }
}